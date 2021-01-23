    Random adomRng = new Random();
    for (int i = 0; i < amount; i++)
    {
    	string rndString = string.Empty;
        char c;
    	for (int t = 0; t < 8; t++)
    	{
    		while (!Regex.IsMatch((c = Convert.ToChar(adomRng.Next(48, 128))).ToString(), "[a-z0-9]")) ;
    		rndString += c;
    	}
    	listBox1.Items.Add(rndString);
    }
