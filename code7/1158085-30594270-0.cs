    if (answer == (num1 * num2)) 
    {
        int responsegen = numbergenerator.Next (1, 4);
        switch (responsegen)  
        {
            case 1:
                Console.WriteLine ("Congrats! You're a natrual");
                break;
            case 2:
                Console.WriteLine ("Correct, Mini Einstein maybe?");
                break; // <-- you need a break here as well
            default:
                Console.WriteLine ("Right answer , are you cheating?");
        } // <-- here
    } 
    else
    {
        int diff = (answer - (num1 * num2));
        if (diff == 1) 
        {
            Console.WriteLine ("OHH so close you were only of by one number!");
        }
        if (diff <=10) 
        {
            Console.WriteLine ("Incorrect but you were close, only of by " + diff + "better luck next time!");                  
        }
    }
