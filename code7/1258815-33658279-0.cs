         string[] lines = File.ReadAllLines(inputFile, Encoding.GetEncoding(1257));
         var filtered = lines
             .Where(line => line.Length > 0) // remove all empty lines
             .Except(lines.OrderByDescending(line => line.Length).Take(10)); // remove 10 longest lines
         File.WriteAllLines(outputFile, filtered);
