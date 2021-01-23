    string line;    
    using (var reader = new StreamReader(inFile))
        using (var writer = new StreamWriter(inFile + ".NonAsciiChars"))
            while ((line = reader.ReadLine()) != null)
            {
                ... // code to process line
                writer.Write(line);
            }
