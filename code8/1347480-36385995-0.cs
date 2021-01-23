    //this is your price variable
    static int price = 42;
    //function to check it
    static void CheckPrice()
    {
        Console.WriteLine("price of foo " + price + "$");
    }
    static void Main()
    {
        bool exit = false;
        do
        {
            //write at begin ">"
            Console.Write(">");
            //wait for user input
            string input = Console.ReadLine();
            // if input is "checkprice"
            if (input == "checkprice") CheckPrice();
            if (input == "exit") exit = true;
        } while (!exit);
    }
