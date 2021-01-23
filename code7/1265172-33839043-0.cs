    while (!file.EndOfStream)
    {
       String line = file.ReadLine();
       if (String.IsNullOrWhiteSpace(line))
           continue;
       string[] tokens = line.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
       fizzBuzz(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
    }
