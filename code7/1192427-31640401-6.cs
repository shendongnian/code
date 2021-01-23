    using System;
    using System.Data;
    using System.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		var dt = new DataTable();
    		dt.Columns.Add("Key", typeof(string));
    
    		dt.Rows.Add("Key1Value");
    		dt.Rows.Add("Key2Value");
    		dt.Rows.Add("Key3Value");
    		dt.Rows.Add("Key4Value");
    		dt.Rows.Add("Key5Value");
    		dt.Rows.Add("Key6Value");
    		
    		var dt2 = dt.Clone();
    		foreach (DataRow dr in dt.Rows)
    		{
    			string key = dr["Key"].ToString();
    			var dRow = dt2.NewRow();
    			dRow.ItemArray = dr.ItemArray;
    			dt2.Rows.InsertAt(dRow, getPosition(key));
    		}
    		
    		foreach (DataRow dr in dt2.Rows)
    		{
    			Console.WriteLine(dr["Key"]);
    		}
    		
    		Console.Write("Press any key to continue . . . ");
    		Console.ReadKey(true);
    	}
    	
    	static int getPosition(string key)
    	{
    		switch (key)
    		{
    			case "Key5Value":
    				return 0;
    			case "Key6Value":
    				return 1;
    			case "Key1Value":
    				return 2;
    			case "Key2Value":
    				return 3;
    			case "Key3Value":
    				return 4;
    			case "Key4Value":
    				return 5;
    			default:
    				return -1;
    		}
    	}
    }
