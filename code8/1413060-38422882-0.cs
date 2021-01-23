    string[] lines = System.IO.File.ReadAllLines(@fileLocal);
    List<string> s1234 = new List<string>();    
    List<string> s2582 = new List<string>();  
    foreach (string line in lines)
    {
    		string[] linee = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    
    		if(linee[0].ToString() == "S/1234"){
    			s1234.Add(linee[2].ToString());	
    		}else{
    			s2582.Add(linee[2].ToString());	
    		}
    }
