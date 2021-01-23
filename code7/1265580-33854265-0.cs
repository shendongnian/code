    public static void GetDigits(ref int[] callNumberArray, ref bool valid)
        {
        Console.WriteLine("Please enter the code you wish to dial.");
        while ( valid == false)
        {//This loop will reiterate the read() function if the code is not valid.
            valid = true;
            for (int i = 0; i < 7; i++ )
            {
                if (i != 6 && i!= 5 && i != 5 && i != 4 && i != 3 && i != 2 && i != 1 && i != 0)
                {
                    i = 0;
                }
                callNumberArray[i] = Console.Read();// I want to change this
            }
            for (int i = 0; i < 7; i++)
            {
                if(!valid) break;
                if (i != 6 && i != 5 && i != 5 && i != 4 && i != 3 && i != 2 && i != 1 && i != 0)
                {
                    i = 0;
                }
                if (callNumberArray[0] == 53)
                {
                    valid = false;
                }
                if (callNumberArray[i] < 49)
                {
                    valid = false;
                }
                if (callNumberArray[i] > 57 && callNumberArray[i] < 65)
                {
                    valid = false;
                }
                if (callNumberArray[i] > 90 && callNumberArray[i] < 97)
                {
                    valid = false;
                }
                if (callNumberArray[i] > 122)
                {
                    valid = false;
                }
            }
            if (valid == false)
            {
                Console.WriteLine("You entered an invalid code. Please re-enter your code.");
            }
        }
