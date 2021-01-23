	using System;
	using System.Threading.Tasks;
	using EdgeJs;
	class Program
	{
		public static async void Start()
		{
			var func = Edge.Func(@"
				return function (data, callback) {
					callback(null, 'Node.js welcomes ' + data);
				}
			");
			Console.WriteLine(await func(".NET"));
		}
		static void Main(string[] args)
		{
			Task.Run((Action)Start).Wait();
		}
	}
