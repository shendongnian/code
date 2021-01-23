    Console.WriteLine("Can you guess the numbers that have appeared on the screen respectively?");
                for (int i = 1; i < num.Length+1; i++)
                {
                    Console.Write(i + ". ");
                    string temp = Console.ReadLine();
                    userGuess[i-1] = Convert.ToInt32(temp);
    
                }
    
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i] == userGuess[i])//Here's my problem. I am unable to 
                    //test whether my guess resides in the num array.
                    {
                        count++;
                    }
                }
    
                Console.WriteLine("You got " + count + " guesses right.");
