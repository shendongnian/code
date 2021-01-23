    //Probably want to use Load if you're using a file
    XDocument xDoc = 
    		XDocument.Parse (@" 
    		<items>
    			<item>
    			<id>1</id>
    			<row1>abc</row1>
    			<row2>abc</row2>
    			<needthis>
    			<first>John</first>
    			<last>John</last>
    			</needthis>
    			</item>
    		</items>");
    		
    var items = from item in xDoc.Descendants("item") 
                from needThis in item.Descendants("needthis")
                select new 
    			{		Id = item.Element("id").Value,
    			        Row1 = item.Element("row1").Value,
    					first = needThis.Element("first").Value,
    					last = needThis.Element("last").Value
    			};
    
    foreach (var item in items)
    {
    	 Console.WriteLine(item.Id);
    	 Console.WriteLine(item.Row1);
    	 Console.WriteLine(item.first);
    	 Console.WriteLine(item.last);
    }
