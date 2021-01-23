	public class Program
	{
		public class A : I
		{
			public string Word { get; set; }
			public int Number { get; set; }
		}
		public interface I
		{
			int Number { get; set; }
		}
		public static void listToJSON(List<I> myList, ref List<string> JSONElements)
		{
			foreach (var element in myList) {
				JSONElements.Add(JsonConvert.SerializeObject(element));
			}
		}
		static void Main(string[] args)
		{
			List<I> myList = new List<I>();
			myList.Add(new A { Word = "hello", Number = 1});
			myList.Add(new A { Word = "goodbye", Number = 2});
			List<string> jsonElements = new List<string>();
			listToJSON(myList, ref jsonElements);
			Console.WriteLine(string.Join("\n", jsonElements));
			Console.WriteLine("Done, press any key...");
			Console.ReadKey();
		}
	}
