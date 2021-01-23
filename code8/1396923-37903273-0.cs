	public class TestObject
	{
		public int Col1 { get; set; }
		public int Col2 { get; set; }
		public string Col3 { get; set; }
		public DateTime Col4 { get; set; }
	}
	[TestMethod]
	public void LoadFromCollection_MemberList_Test()
	{
		//http://stackoverflow.com/questions/32587834/epplus-loadfromcollection-text-converted-to-number/32590626#32590626
		var TestObjectList = new List<TestObject>();
		for (var i = 0; i < 10; i++)
			TestObjectList.Add(new TestObject {Col1 = i, Col2 = i*10, Col3 = (i*10) + "E4"});
		//Create a test file
		var fi = new FileInfo(@"c:\temp\LoadFromCollection_MemberList_Test.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			//Do NOT include Col1
			var mi = typeof (TestObject)
				.GetProperties()
				.Where(to => to.Name != "Col1")
				.Select(pi => (MemberInfo)pi)
				.ToArray();
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromCollection(TestObjectList, true, TableStyles.Dark1, BindingFlags.Public| BindingFlags.Instance, mi);
			pck.Save();
		}
	}
