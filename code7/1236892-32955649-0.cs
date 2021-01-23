            string s = "ABCD";
            foreach (char oneChar in s.ToCharArray())
            {
                switch (oneChar)
                {
                    case 'A':
                        Console.WriteLine("Do A stuff");
                        break;
                    case 'B':
                        Console.WriteLine("Do B stuff");
                        break;
                    case 'C':
                        Console.WriteLine("Do C stuff");
                        break;
                    case 'D':
                        Console.WriteLine("Do D stuff");
                        break;
                    default:
                        break;
                }
            }
