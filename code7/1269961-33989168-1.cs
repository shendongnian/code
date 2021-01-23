    //read all lines
    var lines = System.IO.File.ReadAllLines("C:/path/to/file.txt");
    //loop through all lines
    foreach(var line in lines)
    {
        //split the line
        var splitString = line.Split(new char[] { '\t' });
        //pull out some data from the 6th column
        double avDP = double.Parse(splitString[5]);
        //save the data wherever you want
    }
