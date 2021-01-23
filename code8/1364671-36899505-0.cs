    for (int n = 2; n <= 14; n++)
    {
        for (int c = 1; c <= 4; c++)
        {
            switch (n)
            {
                case 11:
                    Console.Write("J" + " ");
                    break;
                case 12:
                    Console.Write("Q" + " ");
                    break;
                case 13:
                    Console.Write("K" + " ");
                    break;
                case 14:
                    Console.Write("A" + " ");
                    break;
                default:
                    Console.Write(n.ToString() + " ");
                    break;
            }
            switch (c)
            {
                case 1:
                    Console.WriteLine("H");
                    break;
                case 2:
                    Console.WriteLine("D");
                    break;
                case 3:
                    Console.WriteLine("S");
                    break;
                case 4:
                    Console.WriteLine("C");
                    break;
                default:
                    Console.WriteLine("?");
                    break;
            }
                    
        }
    }
    Console.ReadKey();
