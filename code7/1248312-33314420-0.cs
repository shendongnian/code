    try
    {
    int a, b, c;
    int count = 0;
    Console.WriteLine("Vnesite prvo stevilo: ");
    a = Convert.ToInt32(Console.ReadLine());
    bool a1 = (a % 3 == 0);
    if (a1) count++;
    Console.WriteLine("Vnesite drugo stevilo: ");
    b = Convert.ToInt32(Console.ReadLine());
    bool b1 = (b % 3 == 0);
    if (b1) count++;
    Console.WriteLine("Vnesite tretje stevilo: ");
    c = Convert.ToInt32(Console.ReadLine());
    bool c1 = (c % 3 == 0);
    if (c1) count++;
    if (count == 3)
    {
        b++;
        c += 2;
    }
    if (count == 2)
    {
        if (a1 & b1 & a != b) b++;
        else if ((a1 & c1 && a == c) || (b1 & c1 & b == c)) c++;
        else
        {
            int[] abc = { a, b, c };
            if (a == abc.Max()) a++;
            else if (b == abc.Max()) b++;
            else if (c == abc.Max()) c++;
        }
    }
    Console.WriteLine(string.Format("{0} {1} {2}", a, b, c));
    Console.ReadKey();
    }
    catch
    {
        Console.WriteLine("dog");
        Console.ReadKey();
    }
