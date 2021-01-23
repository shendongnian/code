    var numbers = new Dictionary<string, string>();
        
    using(var file = File.OpenText(pathToFile))
    {
            while (!file.EndOfStream)
            {
                var lineParts = file.ReadLine().Split(" ".ToCharArray(), 2); //split line around space characters
                numbers[lineParts[0]] = lineParts[1];
            }
    }
