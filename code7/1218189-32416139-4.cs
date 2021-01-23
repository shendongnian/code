    ....
    Console.WriteLine(szReceived);
    Console.WriteLine("Recieved..." + szReceived + "---");
    
    var split = szReceived.Split('|');
    if(split.Length==0)return;
    
    var command = split[0];
    var parameters = new string[0];
    
    if (split.Length > 0)
    	parameters = split[1].Split(',');
    
    switch (command)
    {
    	case "ping":
    		Console.WriteLine("Ping wird ausgeführt!");
    		ASCIIEncoding asen = new ASCIIEncoding();
    
    		foreach (var p in parameters)
    			Console.WriteLine(p);
    
    		s.Send(asen.GetBytes("PONG !"));
    		s.Close();
    
    		break;
    
    	case "logout":
    
    		break;
    }
    ....
