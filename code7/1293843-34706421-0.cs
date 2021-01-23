    public static List<float> menuChoose()
            {
    
                List<float> selection = new List<float>();
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
    
                        Console.Clear();
                        Console.WriteLine("Give lenght:");
                        float result;
                        float.TryParse(Console.ReadLine(), out result);
                        selection.Add(result);
                        break;
    
                    case ConsoleKey.D2:
    
                        Console.WriteLine("2");
                        break;
    
                    case ConsoleKey.D3:
                        Console.WriteLine("3");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
              return selection;
    
            }
