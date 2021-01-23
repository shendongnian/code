    using System;
    
    namespace so_foreach_bounds
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			//System.Text.StringBuilder newFile = new System.Text.StringBuilder();
    			string txtList= "guest_list.txt";    
    			string[] file = System.IO.File.ReadAllLines(txtList);    
    			int x = file.Length;
    			System.Collections.Generic.List<string[]> list = new System.Collections.Generic.List<string[]> ();
    			
    			foreach (string line in file)
    			{
    				string[] sliced = line.Split('|');
    				list.Add(sliced);
    			}
    
    			foreach (string[] person in list)
    			{
    				Console.WriteLine (String.Join(", ", person));
    
    				if (person[0] =="Gary")
    				{
    					string txtAdd = person[1];
    					string txtPhone = person[2];
    					string txtpeople = person[3];
    					if (person[4] == "n" )
    					{
    					}
    					else
    					{
    						bool has_resvped = true;
    					}
    					break;
    				}
    
    			}
    		}
    	}
    }
