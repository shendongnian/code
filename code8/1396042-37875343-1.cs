    List<int> Numbers = System.IO.File.ReadAllLines("Your File Path")
                       .Select(N=> Convert.ToInt32(N)).ToList();
    Console.WriteLine(Numbers.Average());
    Console.WriteLine(Numbers.Max());
    Console.WriteLine(Numbers.Min());
