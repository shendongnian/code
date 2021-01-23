    using System;
    public interface IItem
    {
    	string id {get;set;}
    }
    
    
    public class Item : IItem
    {
    	public string id{get;set;}
    }
    
    public class BaseFactory<T>
    	where T: IItem, new()
    {
    	public DelegateHolder.MakeWithID<T> funcA;
    	public DelegateHolder.MakeWithIDAndOther<T> funcB;
    }
    
    public class TypedFactory<T> : BaseFactory<T>
    	where T : IItem, new()
    {
    		
    		public TypedFactory()
    		{
    			funcA = makeNew;
    			funcB = makeNewFromOther;
    		}
    		
    		public T makeNew(string itemId)
    		{
    			T _item = new T();
    			_item.id = itemId;
    			return _item;
    		}
    		
    		public T makeNewFromOther(string itemId, T other)
    		{
    			T _item = new T();
    			_item.id = itemId;
    			return _item;
    		}
    		
    }
    
    public class DelegateHolder
    {
    	public delegate T MakeWithID<T>(string id) where T: IItem, new();
    	public delegate T MakeWithIDAndOther<T>(string id, T other) where T: IItem, new();
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var x = new TypedFactory<Item>();
    		BaseFactory<Item> factory = x;
    		
    		Item someItem = factory.funcA("I am alive");
    		
            Console.WriteLine(someItem.id);
    		Console.WriteLine(factory.funcB("I am alive too", someItem).id);
    	}
    }
