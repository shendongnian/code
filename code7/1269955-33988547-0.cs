    string number = Console.ReadLine();
    int sum = 0;
    foreach (char c in number)
    {
        sum += int.Parse(c.ToString());
    }
    Console.WriteLine(sum);
