    Console.Write("Number: ");
    var num = int.Parse(Console.ReadLine());
    var range = Enumerable.Range(1, num);
    var str = String.Concat(range.Select(x => x.ToString()));
    Console.WriteLine(str);
    var sum = range.Sum();
    Console.WriteLine("\nThe sum is: {0}", sum);
    Console.ReadLine();
