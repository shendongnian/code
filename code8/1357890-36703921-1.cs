    public class MyReallyPersistentList<T> : List<T>
    {
    	public MyReallyPersistentList()
    	{
    		AppDomain.CurrentDomain.ProcessExit += (sender, args) => 
    		{
                var items = this.Select(i => i?.ToString());
    			File.AppendAllLines(@"C:\temp\mylist.txt", items);
    		};
    	}
    }
