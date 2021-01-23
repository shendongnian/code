    List<int> elements = new List<int>();
    while (null != (line = streamReader.ReadLine())) 
    {
        if(line.Contains("["))
        {
            //Prevent reading in the next section
            break;
        }
        string[] split = line.Split(Convert.ToChar(" "));
        //Each element in split will be each number on each line.
        for(int i=0;i<split.Length;i++)
        {
            elements.Add(Convert.ToInt32(split[i]));
        }
        
    }
