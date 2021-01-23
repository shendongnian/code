    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); //input.
        // Use a string to store the values before reverting.
        string result = "";
        // If you have performance issues, use a StringBuilder instead of string.
        StringBuilder strBuilder = new StringBuilder();
        while (n >= 1) // it stops if there is no number to divide.
        {
            int digit = n % 2; // this shows the digit.
            result += digit; // string approach
            strBuilder.Append(digit); // StringBuilder approach
            n = n / 2; // for calculating another digit.
        }
        // Now you will have result == strBuilder.ToString()
        // from this point you can use which you prefer (I use result in this example)
        
        // OPTION 1: Use Reverse() extension method and then convert to a printable array.
        Console.WriteLine(result.Reverse().ToArray());
        // OPTION 2: Print the string backwards.
        for (int i = result.Length - 1; i >= 0; i--)
            Console.Write(result[i]);
    }
