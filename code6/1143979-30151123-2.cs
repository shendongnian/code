    public static void SetElement(int id, string text)
    {
    	var doc = XDocument.Load(PATH);
    	var str = docx.Descendants()
    				  .FirstOrDefault(o => (int?)o.Attribute("id") == id);
    	var cdata = (XCData)str.FirstNode;
    	cdata.Value = text;
    	
    	doc.Save(PATH);
    }
