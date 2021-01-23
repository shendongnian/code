    int altura; 
    Console.Write("Dar altura: ");
    altura = int.Parse(Console.ReadLine());
  
    var lines = Enumerable.Range(1, altura).Select(i =>
    {
       var line = Enumerable.Range(1, i).ToArray();
       var reverse = line.Reverse().Skip(1).ToArray();
       return String.Join("", line.Concat(reverse).Select(c => c.ToString()).ToArray())
    });
    foreach(string line in lines)
    {
        Console.Writeline(line);
    }
     
