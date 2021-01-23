    if (answer == (num1 * num2)) 
    {
        int responsegen = numbergenerator.Next(1, 4);
        switch (responsegen)  
        {
            case 1:
                Console.WriteLine("Congrats! You're a natural");
                break;
            case 2:
                Console.WriteLine("Correct, Mini Einstein maybe?");
                break; // <-- you need a break; here...
            default:
                Console.WriteLine("Right answer, are you cheating?");
                break; // <-- ...and here.
        } // <-- add a brace here
    } 
    else
    {
        int diff = answer - (num1 * num2);
        if (diff == 1) 
        {
            Console.WriteLine("OHH so close, you were only off by one number!");
        }
        else if (diff <= 10) 
        {
            Console.WriteLine("Incorrect but you were close - only off by " + diff + ". Better luck next time!");                  
        }
    }
