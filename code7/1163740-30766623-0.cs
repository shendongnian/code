    String line = "qwerty/asdfg/xxx/zxcvb";
	string[] words = line.Split('/');
	string last = words.First();
	
	foreach (string word in words)
	{
    	if (word.IndexOf("xxx", StringComparison.CurrentCulture) > -1)
    	{
        	Console.WriteLine(last);
    	}
		else 
		{
			last = word;
		}
	}
