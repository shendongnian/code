    while (input[0] != "search")
            {
                input = Console.ReadLine().Split('-');
                for (int i = 0; i < input.Length; i++)
                {
                    if (dict.ContainsKey(input[i]))
                    {
                        dict.Remove(input[i]);
                    }
                dict.Add(input[0],input[1]);
                }
            }
