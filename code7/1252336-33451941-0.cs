    var count = int.Parse(Console.ReadLine());
    var random = new Random();
    var numbers = new List<int>();
    for(var i = 0; i < count; ++i)
    {
        numbers.Add(random.Next(0, 1000));
    }
    System.IO.File.WriteAllLines(@"C:\output.txt", numbers.Select(x => x.ToString()).ToArray());
