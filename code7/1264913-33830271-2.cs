    Dictionary<string, string> Errors = new Dictionary<string, string>();
    string lastProcessingNumber = string.Empty;
    using (StreamReader reader = new StreamReader("log.txt"))
    {
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if(line.StartsWith("PROCESSING"))
            {
                lastProcessingNumber = line.Replace("PROCESSING: ", string.Empty);
                Errors.Add(lastProcessingNumber, string.Empty);
            }
            if(line.StartsWith("ERROR") && lastProcessingNumber != string.Empty)
            {
                Errors[lastProcessingNumber] = line.Replace("ERROR: ", string.Empty);
            }
        }
    }
