    void Main()
    {
    	var list = new CustomList<int>();
    	list.Add(1);
    	list.Add(2);
        list[1] = 5;
    	list[1].Dump(); //output 5
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
           set
	       {
	   		   list[index - 1] = value;
	       }
       	}
    }
