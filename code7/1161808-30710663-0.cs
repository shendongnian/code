    List<String> lines = new List<String>();
    using (StreamReader reader = new StreamReader("file.txt"))
	{
        String line; 
        while((line = reader.ReadLine()) != null)
	    {
            lines.add(line);
        }
	}
    //Now you got all lines of your CSV
    //Create your file with EPPLUS
    foreach(String line in lines)
    {
        var values = line.Split(';');
        foreach(String value in values)
        {
            //use EPPLUS library to fill your file
        }
    }
