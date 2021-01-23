    using (StreamWriter sw = new StreamWriter("C:\\writetest\\writetest.txt"))
    {
    	string mydirpath = "C:\\chat\\";
    
    	string[] txtFileList = Directory.GetFiles(mydirpath, "*.txt");
    
    	Regex regex = new Regex("(^.*?(?:AM|PM).*?)\r?\n.*(MEASURED VELOCITY:.*?$).*",
            RegexOptions.Multiline | RegexOptions.Singleline);
    	foreach (string txtName in txtFileList)
    	{
    		using (System.IO.StreamReader sr = new System.IO.StreamReader(txtName))
    		{
    			string text = sr.ReadToEnd();
    			sw.WriteLine(regex.Replace(text, "$1, $2"));
    		}
    	}
    }
