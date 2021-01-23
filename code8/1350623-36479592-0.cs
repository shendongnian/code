    foreach(var i in letters)
    {
    	Console.WriteLine(i);
    	
    	foreach(var a in numbers)
    	{
    		if (a.isPrinted) //if it has been printed already
    		{
    			continue; //skip ahead
    		}
    		else
    		{
    			Console.WriteLine(a.number);
    			a.isPrinted = true;
    			break; //stop and jump out of the foreach loop
    		}
    	}
    }
