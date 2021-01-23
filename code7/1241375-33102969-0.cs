    var xdoc = XDocument.Load(...);
    if (xdoc.Root != null)
    {
    	XNamespace xNs = "http://schemas.microsoft.com/winfx/2006/xaml";
    	XNamespace sysNs = "clr-namespace:System;assembly=mscorlib";
    	XNamespace locNs = "http://temp/uri";
    
    	foreach (var str in xdoc.Root.Elements(sysNs + "String"))
    	{
    		var keyAttribute = str.Attribute(xNs + "Key");
    		if (keyAttribute == null)
    		{
    			continue;
    		}
    		var noteAttribute = str.Attribute(locNs + "Note");
    
    		var translation = new Translation
    			{
    				LocaleKey = locale,
    				Note = noteAttribute != null ? noteAttribute.Value : null,
    				Text = str.Value
    			});
    	}
    }
