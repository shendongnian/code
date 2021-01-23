        foreach (string item in text.Split(' '))
        {
            bool testerino = flame.Any(item.Contains);
            if (testerino)
            {
                Console.WriteLine("1");
                break;
            }
        }
