		string line = "   adj 1: text   ";
		line = line.TrimStart(' ');
		if (line.StartsWith("adj"))
		{
			line = line.Remove(0, 3);
			line = "j" + line;
		}
        else if (line.StartsWith("adv"))
		{
			line = line.Remove(0, 3);
			line = "v" + line;
		}
           
           // line == "j 1: text    "
       
           line = line.Trim();
    
           // line == "j 1: text"
