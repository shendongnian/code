    public class Program
    {
    	public static void Main()
    	{
    		var dt = SeedData();
    		var json = JsonConvert.SerializeObject(
    				dt,
    				Newtonsoft.Json.Formatting.Indented,
    				new DataTableJsonConverter(typeof(DataTable)));
    		Console.WriteLine(json);
    	}
    
    	public static DataTable SeedData()
    	{
    		var dt = new DataTable();
    		dt.Columns.Add("Name");
    		dt.Columns.Add("Position");
    		for (var i = 0; i < 3; ++i)
    		{
    			dt.Rows.Add(new object[] { "Shaun", "Developer" });
    		}
    		return dt;
    	}
    }
