	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reactive.Linq;
	using System.Reactive.Subjects;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	namespace RX_2
	{
		public static class Program
		{
			static void Main(string[] args)
			{
				Subject<bool> stream = new Subject<bool>();
				Task.Run(
					() =>
					{
						for (int i = 0; i < 4; i++)
						{
							Thread.Sleep(TimeSpan.FromMilliseconds(500));
							stream.OnNext(false);
						}
						stream.OnNext(true);
					});
				Console.Write("Start\n");
				stream.Where(o => o == true).BlockUntilEvent();
				Console.Write("Stop\n");
				Console.ReadKey();
			}
			public static void BlockUntilEvent(this IObservable<bool> stream)
			{
				BlockingCollection<bool> blockingCollection = new BlockingCollection<bool>();
				stream.Subscribe(blockingCollection.Add);
				var result = blockingCollection.Take();
			}
		}
	}
