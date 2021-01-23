    public void OutputProductElement( XElement inElem, int inIndentLevel )
    {
    	string theIndentation = new string( Enumerable.Repeat( '\t', inIndentLevel ).ToArray());
    	
    	var theValueElements = inElem.XPathSelectElements( "MultiValues/Value" ).Concat(
    		inElem.XPathSelectElements( "Values/Value" )
    		);
    		
    	string theValueList = string.Join( " ", theValueElements.Select( elem => @"""" + elem.Value + @"""" ) );
    	
    	Console.Out.WriteLine( theIndentation + @"""" + (string)inElem.Attribute("ID") + @""" " + theValueList  );
    	
    	//no print all children elemnts
    	inElem.Elements( "Product" ).ToList().ForEach( elem => OutputProductElement( elem, inIndentLevel + 1 ) );
    }
