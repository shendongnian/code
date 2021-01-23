    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{		
    		var text = "BSC,LAC" + Environment.NewLine
    			+ "BSC37,1" + Environment.NewLine
    			+ "BSC38,2" + Environment.NewLine
    			+ "BSCN10,3"+ Environment.NewLine
    			+ "BSCN10,4";
    		
    		var rows = text.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
    		var columns = rows[0].Split(',').ToList();
    		
    		foreach(var row in rows.Skip(1)) {
    			var cells = row.Split(',');
    			
    			string regionCode = "";
    
    			if(cells[columns.IndexOf("BSC")] == "BSC37" 
    			  || cells[columns.IndexOf("BSC")] == "BSC38") { 
    				regionCode = "AUH";
    			}
    			
    			if(cells[columns.IndexOf("BSC")] == "BSCN10")
    			{
    				if(cells[columns.IndexOf("LAC")] == "3") {
    					regionCode = "AUH";
    				} 
                    if(cells[columns.IndexOf("LAC")] == "4") 
    					regionCode = "DXB";
    				}
    			}
    			
    			Console.WriteLine("{0},{1}->{2}",cells[0],cells[1], regionCode);
    		}
    	}
    }
