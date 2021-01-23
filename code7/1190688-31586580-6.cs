    int seed = 0;
    Func<int> natural = () => seed++;
    Console.WriteLine (natural()); // 0
    Console.WriteLine (natural()); // 1
    Console.WriteLine (seed); // 2
