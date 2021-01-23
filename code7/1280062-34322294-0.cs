    void Main()
    {
	    var html = "<a id=\"attr1\" class=\"c1\" attr1=\"x\" attr2=\"y\">a1 c1 attr1</a> <p>a1 c1 attr1 attr2</p>";
	
	    var res = Replace(html, "attr1", "attrA");
    }
    public string Replace(string html, string oldval, string newval)
    {
	    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
	    doc.LoadHtml(html);
	    foreach (var n in doc.DocumentNode.ChildNodes)
	    {
		    foreach (var a in n.Attributes)
		    {
			    if (a.Value.Equals(oldval))
			    {
				    a.Value = newval;
			    }
			    if (a.Name.Equals(oldval))
			    {
				    a.Name = newval;
			    }
		    }
	    }
	
	    return doc.DocumentNode.OuterHtml;
    }
    
