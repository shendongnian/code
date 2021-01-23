                Console.Write("Name: ");
                string userInput = Console.ReadLine();
    
                //The words that you dont want your user to have
                string[] array = new string[2];
                array[0] = "bad";
                array[1] = "reallybad";
    
                for (int i = 0; i < array.Length; i++)
                {
                    
                    //Used to lower so user cant get away with stuffs like: rEALLyBAd
                    if (userInput.Contains(array[i].ToLower()))
                    {
    
                        Console.WriteLine("Invalid name!");
    
                    }
    
                }
    
                Console.ReadKey();
