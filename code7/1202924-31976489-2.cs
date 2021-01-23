    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static async Task TestAsync(string id, int delay)
    		{
    			// but we might not even have any asynchrony here
    			// but making the method "async" is already enough
    			// for the copy-on-write behavior to trigger
    
    			await Task.Delay(delay).ConfigureAwait(false);
    
    			// copy on write here
    			CallContext.LogicalSetData("name1", "value1-modified-by-" + id); 
    			var mutableData = (MutableData<string>)CallContext.LogicalGetData("name2");
    			Console.WriteLine(CallContext.LogicalGetData("name1"));
    
    			// racing to set mutableData.Data
    			mutableData.Data = "value2-modified-by-" + id;
    			Console.WriteLine(mutableData.Data);
    		}
    
    		static void Main(string[] args)
    		{
    			CallContext.LogicalSetData("name1", "value1");
    			var mutableData = new MutableData<string> { Data = "value2" };
    
    			CallContext.LogicalSetData("name2", mutableData);
    			Console.WriteLine(CallContext.LogicalGetData("name1"));
    
    			Task.WaitAll(TestAsync("A", 1000), TestAsync("B", 1000));
    
    			Console.WriteLine(CallContext.LogicalGetData("name1"));
    			Console.WriteLine(mutableData.Data);
    
    			Console.ReadLine();
    		}
    	}
    
    	class MutableData<T>
    	{
    		readonly object _lock = new Object();
    		T _data = default(T);
    
    		public T Data
    		{
    			get
    			{
    				lock (_lock)
    				{
    					return _data;
    				}
    			}
    			set
    			{
    				lock (_lock)
    				{
    					_data = value;
    				}
    			}
    		}
    	}
    }
