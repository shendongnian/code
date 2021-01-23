	[TestMethod]
	public void Read_To_Collection_Test()
	{	
		//A collection to Test
		var objectcollection = new List<TestObject>();
		for (var i = 0; i < 10; i++)
			objectcollection.Add(new TestObject {Col1 = i, Col2 = i*10, Col3 = Path.GetRandomFileName(), Col4 = DateTime.Now.AddDays(i)});
		//Create a test file to convert back
		byte[] bytes;
		using (var pck = new ExcelPackage())
		{
			//Load the random data
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("data");
			worksheet.Cells.LoadFromCollection(objectcollection, true);
			bytes = pck.GetAsByteArray();
		}
		//*********************************
		//Convert from excel to a collection
		using (var pck = new ExcelPackage(new MemoryStream(bytes)))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets["data"];
			var newcollection = worksheet.ConvertSheetToObjects<TestObject>();
			newcollection.ToList().ForEach(to => Console.WriteLine("{{ Col1:{0}, Col2: {1}, Col3: \"{2}\", Col4: {3} }}", to.Col1, to.Col2, to.Col3, to.Col4.ToShortDateString()));
		}
	}
	
	//test object class
	public class TestObject
	{
		public int Col1 { get; set; }
		public int Col2 { get; set; }
		public string Col3 { get; set; }
		public DateTime Col4 { get; set; }
	}
