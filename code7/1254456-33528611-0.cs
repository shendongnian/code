    void Main()
    {
    	var list = new CustomList<int>();
    	list.Add(1);
    	list.Add(2);
    	
    	list[1].Dump();
    }
    
    public class CustomList<T>
    {
    	IList<T> list = new List<T>();
    	
    	public void Add(T item)
    	{
    		list.Add(item);
    	}
    	
    	public T this[int index]
       	{
           get
           {
               return list[index - 1];
           }
       	}
    }
