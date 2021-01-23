        bool isDivisible;
        //checks if divisible by 5 and sets a value for 'isDivisible'
        if ((sum % 10 == 5) || (sum % 10 == 0))
        {
            Console.WriteLine("\nThe sum is divisible by 5!");
            isDivisible = true;
        }
        else
        {
            Console.WriteLine("\nThe sum is not divisible by 5!");
            isDivisible = false;
        }
