    using System.Collections.Generic;
    
    namespace IRepo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var repo = new Repo();
    
    			var carList = repo.All<Car>(); // ok
    			var truckList = repo.All<Truck>(); // ok
    			//var bananas = repo.All<Banana>(); // compiler error
    		}
    	}
    
    	public class Repo
    	{
    		public List<T> All<T>() where T : IRepoItem
    		{
    			return new List<T>();
    		}
    	}
    
    	public interface IRepoItem { }
    	public class Car : IRepoItem { }
    	public class Truck : IRepoItem { }
    	public class Banana { } // not an IRepoItem
    }
