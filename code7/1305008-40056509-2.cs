    static void Main(string[] args)
    {
        Console.WriteLine("Enter what you want to print!");
        string userPrint = Console.ReadLine();
        Console.WriteLine("Enter the number of times you want to print: ");
        int number = int.Parse(Console.ReadLine());
        while(number > 0){
            Console.WriteLine(userPrint);
            number--;
        }
        Console.ReadLine();
    } 
