    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using ServiceStack.Redis;
    namespace TestRedisRepo
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
                r.Add<User>(new User { Id = r.Next<User>(), Name = "Joachim Nordvik" });
            // We should have 100 users in data store.
            Console.WriteLine("Users In \"Database\" : {0}\n", r.All<User>().Count);
            // Lets print 10 users from data store.
            Console.WriteLine("Order by Id, Take (10) and print users.");
            foreach (var u in r.All<User>().OrderBy(z => z.Id).Take(10))
                Console.WriteLine("ID:{0}, Name: {1}", u.Id, u.Name);
            // Clean up data store.
            Console.WriteLine("\nCleaning up Data Store.\n");
            foreach (var u in r.All<User>())
                r.Del<User>(u);
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
        /// Load {T} into object cache.
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        private void LoadIntoCache<T>() where T : class
        {
            _cache[typeof(T)] = GetAll<T>().Cast<object>().ToList();
        }
        /// <summary>
        /// Add single {T} into cache.
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="entity">class object</param>
        public void Add<T>(T entity) where T : class
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
        /// Delete single {T} from cache.
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="entity">class object</param>
        public void Del<T>(T entity) where T : class
        {
            List<object> list;
            if (_cache.TryGetValue(typeof(T), out list))
            {
                list.Remove(entity);
                _cache[typeof(T)] = list;
                Delete<T>(entity);
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
        public T FindSingleBy<T>(Func<T, bool> predicate) where T : class
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
        private void Delete<T>(T entity) where T : class
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
