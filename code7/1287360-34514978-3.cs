    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    
    		private static Stopwatch timer = new Stopwatch();
    
    		static void Main(string[] args)
    		{
    			/// Initialization
    
    			var _linkedList = new LinkedList<int>();
    
    			for (int i = 0; i < 10; i++)
    				_linkedList.AddLast(i);
    
    			for (int x = 0; x < 1000000; x++)
    				for (var _node = _linkedList.First; _node != _linkedList.Last; _node = _node.Next)
    					FuncFoo(_node.Value);
    			for (int x = 0; x < 1000000; x++)
    				foreach (var _int in _linkedList)
    					FuncFoo(_int);
    			for (int x = 0; x < 1000000; x++)
    			{
    				var _listNode = _linkedList.First;
    				while (_listNode != _linkedList.Last)
    				{
    					FuncFoo(_listNode.Value);
    					_listNode = _listNode.Next;
    				}
    			}
    
    			/// Test 1
    
    			timer.Start();
    
    			for (int x = 0; x < 1000000; x++)
    				for (var _node = _linkedList.First; _node != _linkedList.Last; _node = _node.Next)
    					FuncFoo(_node.Value);
    
    			timer.Stop();
    
    			Console.WriteLine("For Loop: " + timer.Elapsed);
    
    			timer.Reset();
    
    
    			/// Test 2
    
    			timer.Start();
    
    			for (int x = 0; x < 1000000; x++)
    				foreach (var _int in _linkedList)
    					FuncFoo(_int);
    
    			timer.Stop();
    
    			Console.WriteLine("Foreach Loop: " + timer.Elapsed);
    
    			timer.Reset();
    
    
    			/// Test 3
    
    			timer.Start();
    
    			
    
    			for (int x = 0; x < 1000000; x++)
    			{
    				var _listNode = _linkedList.First;
    				while (_listNode != _linkedList.Last)
    				{
    					FuncFoo(_listNode.Value);
    					_listNode = _listNode.Next;
    				}
    			}
    
    			timer.Stop();
    
    			Console.WriteLine("While Loop: " + timer.Elapsed);
    
    			timer.Reset();
    
    
    			///End
    
    			Console.Write("Press any key to continue...");
    
    			Console.ReadKey();
    		}
    
    		private static void FuncFoo(int _num)
    		{
    			_num = (int)Math.Sqrt(1 + 2 + 3 + 4 + 5) * _num;
    		}
    	}
    }
