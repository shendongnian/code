       var target = File
         .ReadLines(fileName)
         .Skip(1) // Skip the line with column names
         .Select(line => line.Replace(' ', ',')); // ... I assume this is the pattern
    
       // Writing back to some other file
       File.WriteAllLines(someOtherFileName, target);
       // In case you want to write to fileName back, materialize:
       // File.WriteAllLines(fileName, target.ToList());
