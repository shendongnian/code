    string str = "Blue is my favourite colour, and Red is my least favourite";
    Type colorType = typeof(System.Drawing.Color);
    // We take only static property to avoid properties like Name, IsSystemColor ...
    System.Reflection.PropertyInfo[] propInfos = colorType.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public);
    string[] Colors = propInfos.Select(m => m.Name).ToArray();
    
    foreach (string color in Colors)
    {
    	if (str.Contains(color))
    	{
    		string replaceColor = "<span style='color:" + color + "'>" + color + "</span>";
    		str = str.Replace(color, replaceColor);
    	}
    }            
    webBrowser1.DocumentText = str;
