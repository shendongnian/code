    class Program
	{
		static void Main(string[] args)
		{
			var lstA = new List<A>();
			var a1 = new A()
			{
				listB = new List<B>()
				{
					new B
					{
						id = 3
					},
					new B
					{
						id = 5
					}
				}
			};
			var a2 = new A()
			{
				listB = new List<B>()
				{
					new B
					{
						id = 1
					},
					new B
					{
						id = 8
					}
				}
			};
			lstA.Add(a1);
			lstA.Add(a2);
			var ids = lstA.SelectMany(r => r.listB.Select(x => x.id));
			foreach (var id in ids)
			{
				Console.WriteLine(id);
			}
			Console.ReadKey();
		}
	}
	public class A
	{
		public List<B> listB { get; set; }
	}
	public class B
	{
		public int id { get; set; }
	}
