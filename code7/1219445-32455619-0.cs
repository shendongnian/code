	namespace ConsoleApplication6
	{
		using System;
		using System.Threading;
		using System.Threading.Tasks;
		class Program
		{
			static void Main(string[] args)
			{
				var tasks = new Task<string>[4];
				tasks[0] = Task.Factory.StartNew(() => new MyServer1().SendRequest("Request1"));
				tasks[1] = Task.Factory.StartNew(() => new MyServer2().SendRequest("Request2"));
				tasks[2] = Task.Factory.StartNew(() => new MyServer3().SendRequest("Request3"));
				tasks[3] = Task.Factory.StartNew(() => new MyServer4().SendRequest("Request4"));
				Task.WaitAll(tasks);
				
				var string1 = tasks[0].Result;
				var string2 = tasks[1].Result;
				var string3 = tasks[2].Result;
				var string4 = tasks[3].Result;
				Console.WriteLine("{0} {1} {2} {3}", string1, string2, string3, string4);
			}
		}
		public abstract class MyServer
		{
			public string SendRequest(string request)
			{
				Thread.Sleep(20000);
				return request.Replace("Request", "Response");
			}
		}
		public class MyServer1 : MyServer {}
		public class MyServer2 : MyServer {}
		public class MyServer3 : MyServer {}
		public class MyServer4 : MyServer {}
	}
----------
	
	Response1 Response2 Response3 Response4
	Press any key to continue . . .
