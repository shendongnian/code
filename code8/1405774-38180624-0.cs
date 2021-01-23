    string[] lines = File.ReadAllLines(@"filename.txt");
    List<Info> infos = new List<Info>();
    foreach(var line in lines)
    {	
    	string name = "";
    	string age = "";
    	if(line.StartsWith("Name:"))
    	{
    		name = line.Replace("Name: ", "");		
    	}
    	else if(line.StartsWith("Age:"))
    	{
    		age = line.Replace("Age: ", "");
    	}
    	Info info = new Info(name, age);
    	infos.Add(info);
    }
