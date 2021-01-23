    string[] Colors = new {"Red", "Green", ... };
    string str = lblsentence.Text;
    foreach(string color in Colors)
    {
    	if(str.Contains(color))
    	{
    		string replaceColor = "<span style='background-color:" + color + "'>" + color + "</span>";
    		str = str.Replace(color, replaceColor);
    	}
    }
    lblsentence.Text = str;
