    SearchResultSet results = session.Search(searchRequest);
     results.GetCount()); 
     IEnumerable columns = results.GetColumns();
     bool printColumns = true;
            while (results.HasNext())
            {
    			if(printColumns){
    				foreach (string column in columns)
    				{
    					Console.WriteLine(String.Format("{0}|", column)); //Will print Unique_ID|Address|etc...
    				}				
    			}
    			printColumns = false;
    			foreach (string column in columns)
    			{
    				Console.Write(String.Format("{0}|", results.GetString(column))); //Will print 234556|555 JOHN STREET|Orlando|FL|32751
    			}			
                Console.WriteLine();
            }
