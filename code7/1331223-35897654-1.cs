    string character = "";
    string[] numbers; //to be calculated at later
    
    var numberList = new List<string>() // for ease of adding values
        
    using(var file = File.OpenText(pathToFile))
    {
            while (!file.EndOfStream)
            {
                var lineParts = file.ReadLine().Split(' '); //split line around space characters
                character += lineParts[0];
                numberList.Add(lineParts[1]);
            }
    }
    
    numbers = numberList.ToArray();
