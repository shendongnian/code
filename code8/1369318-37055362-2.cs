    static void Main(string[] args)
    {
        Console.Write("Insert a number followed by name and finally another number \n" + "* Note: Insert all values separated by comas");
        int value1 = Convert.ToInt32(Console.ReadLine());
        string value2 = Console.ReadLine();
        int value3 = Convert.ToInt32(Console.ReadLine());
        string filePath = "Your path of the location" + "filename.csv";
        File.AppendAllText(filePath, string.Join(",", value1, value2, value3) + Environment.NewLine);
        
        Console.ReadKey();
    }
