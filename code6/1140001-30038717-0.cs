    string toBeReplaced = "The earth is flat or something";
    var sb = new StringBuilder();
  	foreach (var c in toBeReplaced)
   	{
  		if (c != ' ')
   		{
   			sb.Append(c).Append('#');
   		}
   		else
   		{
   			sb.Append('?');
   		}
   	}
   	string result = sb.ToString();
