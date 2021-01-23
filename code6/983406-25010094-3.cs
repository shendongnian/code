    Type colorType = typeof(System.Drawing.Color);
    // We take only static property to avoid properties like Name, IsSystemColor ...
    System.Reflection.PropertyInfo[] propInfos = colorType.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public);
    string[] Colors = propInfos.Select(m => m.Name).ToArray();
    string str = lblsentence.Text;
    foreach(string color in Colors)
    {
    	if(str.Contains(color))
    	{
    		string replaceColor = "<span style='color:" + color + "'>" + color + "</span>";
    		str = str.Replace(color, replaceColor);
    	}
    }
    lblsentence.Text = str;
  
