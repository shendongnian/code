    private static int[] FillArray()
    {
        int[] intArray = new int[10];
        int numbersEntered = 0;
        int intTemp = 0;
        string strTemp = "";
        for (int k = 0; k < 10; ++k)
        {
            Console.WriteLine("Enter a whole number or 999 to quit:  ");
            strTemp = Console.ReadLine();
            while (!int.TryParse(strTemp, out intTemp))
            {
                Console.WriteLine("Input was not in the correct format");
                Console.Write("Please enter a valid number:  ");
                strTemp = Console.ReadLine();
            }
            if (intTemp != 999)
            {
                intArray[k] = intTemp;
                ++numbersEntered;
            }
            else
                break;
        }
        Array.Resize(ref intArray, numbersEntered);
        return intArray;
    }
