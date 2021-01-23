                if (UserInput < 1 || UserInput > 8) 
                {
                    Console.WriteLine("Please enter a number between 1 and 8");
                    goto start;
                }
                else if(array[UserInput - 1] % 2 == 0)
                {
    
                    Console.WriteLine("Number is even");
    
                }else
                {
                    Console.WriteLine("Number is odd");
                }
