    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Collections.Concurrent;
	using ServiceStack.Redis;
	namespace RedisTestRepo
	{
		class Program
		{
			//public static DataRepository Db;
			static void Main(string[] args)
			{
				Repo r = new Repo();
				// We do not touch sequence, by running example we can see that sequence will give Users new unique Id.
				// Empty data store.
				Console.WriteLine("Our User Data store should be empty.");
				Console.WriteLine("Users In \"Database\" : {0}\n", r.All<User>().Count);
				// Add imaginary users.
				Console.WriteLine("Adding 100 imaginairy users.");
				for (int i = 0; i < 99; i++)
					r.Create<User>(new User { Id = r.Next<User>(), Name = "Joachim Nordvik" });
				// We should have 100 users in data store.
				Console.WriteLine("Users In \"Database\" : {0}\n", r.All<User>().Count);
				// Lets print 10 users from data store.
				Console.WriteLine("Order by Id, Take (10) and print users.");
				foreach (var u in r.All<User>().OrderBy(z => z.Id).Take(10))
				{
					Console.WriteLine("ID:{0}, Name: {1}", u.Id, u.Name);
					// Lets update an entity.
					u.Name = "My new Name";
					r.Update<User>(x=>x.Id == u.Id, u);
				}
				// Lets print 20 users from data store, we already edited 10 users.
				Console.WriteLine("\nOrder by Id, Take (20) and print users, we previously edited the users that we printed lets see if it worked.");
				foreach (var u in r.All<User>().OrderBy(z => z.Id).Take(20))
				{
					Console.WriteLine("ID:{0}, Name: {1}", u.Id, u.Name);
				}
				// Clean up data store.
				Console.WriteLine("\nCleaning up Data Store.\n");
				foreach (var u in r.All<User>())
					r.Delete<User>(u);
				// Confirm that we no longer have any users.
				Console.WriteLine("Confirm that we no longer have User entities in Data Store.");
				Console.WriteLine("Users In \"Database\" : {0}\n\n", r.All<User>().Count);
				Console.WriteLine("Hit return to exit!");
				Console.Read();
			}
		}
		public class Repo
		{
			private static readonly PooledRedisClientManager m = new PooledRedisClientManager();
			public Repo()
			{
				// Spool Redis Database into our object cache.
				LoadIntoCache<User>();
			}
			readonly IDictionary<Type, List<object>> _cache = new ConcurrentDictionary<Type, List<object>>();
			/// <summary>
			/// Load {T} into object cache from Data Store.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			private void LoadIntoCache<T>() where T : class
			{
				_cache[typeof(T)] = GetAll<T>().Cast<object>().ToList();
			}
			/// <summary>
			/// Add single {T} into cache and Data Store.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			/// <param name="entity">class object</param>
			public void Create<T>(T entity) where T : class
			{
				List<object> list;
				if (!_cache.TryGetValue(typeof(T), out list))
				{
					list = new List<object>();
				}
				list.Add(entity);
				_cache[typeof(T)] = list;
				Store<T>(entity);
			}
			/// <summary>
			/// Delete single {T} from cache and Data Store.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			/// <param name="entity">class object</param>
			public void Delete<T>(T entity) where T : class
			{
				List<object> list;
				if (_cache.TryGetValue(typeof(T), out list))
				{
					list.Remove(entity);
					_cache[typeof(T)] = list;
					RedisDelete<T>(entity);
				}
			}
			/// <summary>
			/// Tries to update or Add entity to object cache and Data Store.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			/// <param name="predicate">linq expression</param>
			/// <param name="entity">entity</param>
			public void Update<T>(Func<T, bool> predicate, T entity) where T : class
			{
				List<object> list;
				if (_cache.TryGetValue(typeof(T), out list))
				{
					// Look for old entity.
					var e = list.Cast<T>().Where(predicate).FirstOrDefault();
					if(e != null)
					{
						list.Remove(e);
					}
					// Regardless if object existed or not we add it to our Cache / Data Store.
					list.Add(entity);
					_cache[typeof(T)] = list;
					Store<T>(entity);
				}
			}
			/// <summary>
			/// Find List<T>(predicate) in cache.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			/// <param name="predicate">linq statement</param>
			/// <returns></returns>
			public List<T> FindBy<T>(Func<T, bool> predicate) where T : class
			{
				List<object> list;
				if (_cache.TryGetValue(typeof(T), out list))
				{
					return list.Cast<T>().Where(predicate).ToList();
				}
				return new List<T>();
			}
			/// <summary>
			/// Find All {T}
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <returns>List<T></returns>
			public List<T> All<T>() where T : class
			{
				return GetAll<T>().ToList();
			}
			/// <summary>
			/// Find Single {T} in object cache.
			/// </summary>
			/// <typeparam name="T">class</typeparam>
			/// <param name="predicate">linq statement</param>
			/// <returns></returns>
			public T Read<T>(Func<T, bool> predicate) where T : class
			{
				List<object> list;
				if (_cache.TryGetValue(typeof(T), out list))
				{
					return list.Cast<T>().Where(predicate).FirstOrDefault();
				}
				return null;
			}
			public long Next<T>() where T : class
			{
				long id = 1;
				using (var ctx = m.GetClient())
				{
					try
					{
						id =  ctx.As<T>().GetNextSequence();
					}
					catch(Exception ex)
					{
						// Add exception handler.
					}
				}
				return id;
			}
			private void RedisDelete<T>(T entity) where T : class
			{
				using (var ctx = m.GetClient())
					ctx.As<T>().Delete(entity);
			}
			private T Find<T>(long id) where T : class
			{
				using (var ctx = m.GetClient())
					return ctx.As<T>().GetById(id);
			}
			private IList<T> GetAll<T>() where T : class
			{
				using(var ctx = m.GetClient())
				{
					try
					{
						return ctx.As<T>().GetAll();
					}
					catch
					{
						return new List<T>();
					}
				}
			}
			private void Store<T>(T entity) where T : class
			{
				using (var ctx = m.GetClient())
					ctx.Store<T>(entity);
			}
		}
		public class User
		{
			public long Id { get; set; }
			public string Name { get; set; }
		}
	}
