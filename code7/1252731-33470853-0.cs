        string previousLine = null;
        foreach (string line in File.ReadLines(filePath))
        {
            if (previousLine == null)
            {
                // Do something special for the first line?
            }
            else
            {
                // You're past the very first line...
            }
            
            previousLine = line; // Save for next iteration
        }
