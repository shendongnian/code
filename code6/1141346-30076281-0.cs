	void Main()
	{
		const string filePath = @"test.bin";
		Foo graph = new Foo { Bar = "abc"};
		
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		
		// Write
		using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
		{
			binaryFormatter.Serialize(stream, graph);
		}	
		
	
		// Read
		using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
		{
			object result = binaryFormatter.Deserialize(stream);
			Foo resultGraph = (Foo)result;
			
			Console.WriteLine (resultGraph.Bar);
		}
		
	}
	
	[Serializable]
	public class Foo
	{
		public string Bar { get; set; }
	}
	
	
