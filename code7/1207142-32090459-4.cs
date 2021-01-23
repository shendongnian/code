    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    
    namespace Tests
    {
    	// General async extensions
    	public interface IAwaitable<out TResult>
    	{
    		IAwaiter<TResult> GetAwaiter();
    		TResult Result { get; }
    	}
    	public interface IAwaiter<out TResult> : ICriticalNotifyCompletion, INotifyCompletion
    	{
    		bool IsCompleted { get; }
    		TResult GetResult();
    	}
    	public static class AsyncExtensions
    	{
    		public static IAwaitable<TResult> AsAwaitable<TResult>(this Task<TResult> task) { return new TaskAwaitable<TResult>(task); }
    		class TaskAwaitable<TResult> : IAwaitable<TResult>, IAwaiter<TResult>
    		{
    			TaskAwaiter<TResult> taskAwaiter;
    			public TaskAwaitable(Task<TResult> task) { taskAwaiter = task.GetAwaiter(); }
    			public IAwaiter<TResult> GetAwaiter() { return this; }
    			public bool IsCompleted { get { return taskAwaiter.IsCompleted; } }
    			public TResult Result { get { return taskAwaiter.GetResult(); } }
    			public TResult GetResult() { return taskAwaiter.GetResult(); }
    			public void OnCompleted(Action continuation) { taskAwaiter.OnCompleted(continuation); }
    			public void UnsafeOnCompleted(Action continuation) { taskAwaiter.UnsafeOnCompleted(continuation); }
    		}
    	}
    	// Your entity framework
    	public abstract class Entity
    	{
    		// ...
    	}
    	public interface IRepository<out T>
    	{
    		IAwaitable<IEnumerable<T>> GetAllAsync();
    	}
    	public class Repository<T> : IRepository<T> where T : Entity
    	{
    		public IAwaitable<IEnumerable<T>> GetAllAsync() { return GetAllAsyncCore().AsAwaitable(); }
    		protected async virtual Task<IEnumerable<T>> GetAllAsyncCore()
    		{
    			//return await SQLiteDataProvider.Connection.Table<T>().ToListAsync();
    
    			// Test
    			await Task.Delay(1000);
    			return await Task.FromResult(Enumerable.Empty<T>());
    		}
    	}
    	public static class Repository
    	{
    		public static IAwaitable<IEnumerable<Entity>> GetAllEntitiesFrom(string collectionName)
    		{
    			var entityType = Type.GetType(typeof(Entity).Namespace + "." + collectionName, true, true);
    			var repositoryType = typeof(Repository<>).MakeGenericType(entityType);
    			var repository = (IRepository<Entity>)Activator.CreateInstance(repositoryType);
    			return repository.GetAllAsync();
    		}
    	}
    	// Test
    	class EntityA : Entity { }
    	class EntityB : Entity { }
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var t = Test();
    			t.Wait();
    		}
    		static async Task Test()
    		{
    			var a = await Repository.GetAllEntitiesFrom(typeof(EntityA).Name);
    			var b = await Repository.GetAllEntitiesFrom(typeof(EntityB).Name);
    		}
    	}
    }
