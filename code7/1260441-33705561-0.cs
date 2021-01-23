                var arr = new List<string>() { "amelie", "barbon", "cat", "dog", "thomas" };
                var goal = blackline - 2;
                if (goal > -1)
                {
                    if (arr.Count > goal)
                    {
                        Console.WriteLine(arr[goal]);
                    }
                    else
                    {
                        Console.WriteLine(arr[arr.Count - 1]);
                    }
                }
                else
                {                    
                    Console.WriteLine(arr[0]); //if blackline is 1 and answer is suppose to be amelia
                    //Console.WriteLine(arr[arr.Count - 1]); //If blackline is 1 and answer is suppose to be thomas
                }
