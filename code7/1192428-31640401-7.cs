    using System;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		// create table
    		var dt = new DataTable();
    		dt.Columns.Add("Key", typeof(string));
    		dt.Columns.Add("Val1", typeof(int));
    		dt.Columns.Add("Val2", typeof(int));
    		dt.Columns.Add("Val3", typeof(int));
    		dt.Columns.Add("Position", typeof(int));
    		
    		// populate table
    		dt.Rows.Add("Key1Value", 100, 200, 300);
    		dt.Rows.Add("Key2Value", 100, 200, 300);
    		dt.Rows.Add("Key3Value", 100, 200, 300);
    		dt.Rows.Add("Key4Value", 100, 200, 300);
    		dt.Rows.Add("Key5Value", 100, 200, 300);
    		dt.Rows.Add("Key6Value", 100, 200, 300);
    		
    		// initialize dictionary
    		var dict = new Dictionary<string, Tuple<string, int>>() {
    			{ "Key1Value", new Tuple<string, int>("Key 1 Value", 2) }, // Key1Value's new value is Key 1 Value, position is 2
    			{ "Key2Value", new Tuple<string, int>("Key 2 Value", 3) },
    			{ "Key3Value", new Tuple<string, int>("Key 3 Value", 4) },
    			{ "Key4Value", new Tuple<string, int>("Key 4 Value", 5) },
    			{ "Key5Value", new Tuple<string, int>("Key 5 Value", 0) },
    			{ "Key6Value", new Tuple<string, int>("Key 6 Value", 1) }
    		};
    		
    		// set position and new key value
    		dt.AsEnumerable()
    		  .ToList()
    			.ForEach(x => {
    						x["Position"] = dict[x.Field<string>("Key")].Item2;
    						x["Key"] = dict[x.Field<string>("Key")].Item1; // must be the last because the dictionary key is "KeyXValue", not "Key X Value"
    			         });
    		
    		// sort by Position
    		var dt2 = dt.AsEnumerable().OrderBy(x => x.Field<int>("Position"));
    		
    		foreach (DataRow dr in dt2)
    		{
    			Console.WriteLine("{0}, {1}, {2}, {3}, {4}", dr["Key"], dr["Val1"], dr["Val2"], dr["Val3"], dr["Position"]);
    		}
    		
    		Console.Write("Press any key to continue . . . ");
    		Console.ReadKey(true);
    	}
    }
