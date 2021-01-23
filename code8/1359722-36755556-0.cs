    public static void Main()
    {
        Zumba table = new Zumba();
        int[,] zumValues = table.ZumbaValues;
        string[] zumForm = new string[6] { "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
        
        for (int day = 0; day < zumForm.Length; day++)
        {
            Console.Write(zumForm[day]);
            
            for (int time = 0; time < zumValues.GetLength(1); time++)
                Console.Write("\t{0}", zumValues[day, time]);
                
            Console.WriteLine();
        }
    }
