    var lines = File.ReadAllLines("Input.txt");
    foreach (string line in lines)
    {
        var splitBySemiColon = line.Split(';');
        List<int> numbersAtEnd = splitBySemiColon
            .Last()
            .Split(',')
            .Select(s => int.Parse(s))
            .ToList();
        //do whatever you need to with numbersAtEnd... perhaps: foreach (int i in numbersAtEnd) Console.WriteLine(i)
        
    }
