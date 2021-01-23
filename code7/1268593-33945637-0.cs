       var reader = new StreamReader(File.OpenRead("@filelocation"));
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            listA.Add(values[0]);
           // it's ternary operator
           // it checks if second value is equal to LOL, if it's the case 
           // it will add "Laugh out loud" instead of LOL
            listB.Add(values[1] == "LOL" ? "Laugh out loud" : values[1]);
        }
