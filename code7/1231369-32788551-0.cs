    private const string PRINT_PHONE_NUMBERS_IDENTIFIER = "PRINT";
    private static readonly List<string> PhoneList = new List<string>();
    static void Main(string[] args)
    {
        Console.WriteLine($"Add phone numbers to phone list (or {PRINT_PHONE_NUMBERS_IDENTIFIER} to print list so far): ");
        string input;
        while ((input = Console.ReadLine()) != null) // Keeps reading since input will never be null.
        {
            if (input == PRINT_PHONE_NUMBERS_IDENTIFIER)
            {
                PrintAllNumbers();
            }
            else if (IsValidPhoneNumber(input))
            {
                Console.WriteLine("CONSISTENT");
                PhoneList.Add(input);
            }
            else
            {
                Console.WriteLine("NOT CONSISTENT");
            }
        }
    }
    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        return !phoneNumber.StartsWith("991");
    }
    private static void PrintAllNumbers()
    {
        if (PhoneList.Any())
        {
            foreach (var phoneNumber in PhoneList)
            {
                Console.WriteLine(phoneNumber);
            }
        }
        else
        {
            Console.WriteLine("Phone list is empty");
        }
    }
