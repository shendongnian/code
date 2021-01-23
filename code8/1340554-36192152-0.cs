    char[] arr = new char[5];
    Console.WriteLine("Please Enter 5 Letters only: ");
    string inputstring = Console.ReadLine();
    
    if (Regex.IsMatch(inputstring, @"^[a-zA-Z]+$"))
    {
        arr = inputstring.ToCharArray();
        Console.WriteLine("You have entered the following inputs: ");
        //display
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Enter valid inputs and try again");
        Console.ReadLine();
    }
}
