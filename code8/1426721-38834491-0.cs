    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var writer = new StreamWriter(stream))
    	using (var reader = new StreamReader(stream))
    	using (var csv = new CsvReader(reader))
    	{
    		writer.WriteLine("1,a,b,c");
    		writer.WriteLine("2,d,e,f");
    		writer.Flush();
    		stream.Position = 0;
    		
    		csv.Configuration.HasHeaderRecord = false;
    		csv.Configuration.RegisterClassMap<TestMap>();
    		csv.GetRecords<Test>().Dump();
    	}
    }
    
    public class Test
    {
    	public int Id { get; set; }
    	public List<string> Names { get; set; }	
    }
    
    public class TestMap : CsvClassMap<Test>
    {
    	public TestMap()
    	{
    		Map(m => m.Id);
    		Map(m => m.Names).ConvertUsing(row =>
    		{
    			var list = new List<string>();
    			list.Add(row.GetField( 1 ));
    			list.Add(row.GetField( 2 ));
    			list.Add(row.GetField( 3 ));
    			return list;
    		});
    	}
    }
