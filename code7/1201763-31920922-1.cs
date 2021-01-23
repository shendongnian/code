    for (int i = 0; i < 10; i++)
    {
        while (i < 5)
        {
            Console.Write(i + " ");
            goto OutsideWhile;
        }
      OutsideWhile:
            continue; 
    }
    // 0 1 2 3 4
