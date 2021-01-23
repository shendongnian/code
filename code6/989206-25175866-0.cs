    using (var reader = new StreamReader(@"C:\t\input.txt"))
    using (var writer = new StreamWriter(@"C:\t\Output.txt"))
    {
        string line;
        var insideDynamicContent = false;
        while ((line = reader.ReadLine()) != null)
        {
            if (!insideDynamicContent
                  && !line.StartsWith(@"//DYNAMIC-CONTENT-START"))
            {
                writer.WriteLine(line);
                continue;
            }
    
            if (!insideDynamicContent)
            {
                writer.WriteLine("[replacement]");
    
                // write to file replacemenet
    
                insideDynamicContent = true;
            }
            else
            {
                if (line.StartsWith(@"//DYNAMIC-CONTENT-END"))
                {
                    insideDynamicContent = false;
                }
            }
        }
    }
