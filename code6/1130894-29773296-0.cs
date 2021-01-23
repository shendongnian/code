    var stream = new FileStream("myfile.txt", FileMode.Open);
    var streamReader = new StreamReader(stream);
    while (!streamReader.EndOfStream)
    {
       // read in the current line of the file
       var line = streamReader.ReadLine();
       if (string.IsNullOrWhiteSpace(line))
            continue;
       // split the line by the hyphen, trim the whitespace
       var split = line.Split(new[] { '-' }).Select(x => x.Trim()).ToArray();
       // parse the time, use the current date for the day
       var time = DateTime.Parse(split[0]);
       // save your action for later
       var action = split[1];
       // compare the time in the file with the current time, use a 1 second tolerance
       if ((time - DateTime.Now) < TimeSpan.FromSeconds(1))
       {
            // if the current time is within 1 second of the time in the file
            switch(action)
            {
                 case "SP":
                    break;
                 default:
                    break;
            }
       }
    }
