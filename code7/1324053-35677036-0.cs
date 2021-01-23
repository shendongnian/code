    float Paper2;
    while (true)
    {
        try
        {
            Paper2 = float.Parse(Console.ReadLine());
            if (Paper2 > 10)
            {
                throw new Exception();
            }
            else
            {
                break;
            }
        }
        catch
        {
            Console.WriteLine("༼ つ ◕_◕ ༽つ error!");
        }
    }
