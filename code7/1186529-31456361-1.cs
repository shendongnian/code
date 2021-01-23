    bool flag = false;
    if (variable > 1)
    {
        if (!flag)
        {
            Console.Writeline(DateTime.UtcNow.Ticks);
            flag = true;
        }
    }
