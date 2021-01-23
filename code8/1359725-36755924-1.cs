    static public void Main()
    {
        Zumba table = new Zumba();
        int[,] zumValues = table.ZumbaValues;
        string[] zumForm = new string[6] { "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
        for (int z = 0; z < zumForm.GetLength(0); z++)
        {
            Console.Write("{0}", zumForm[z]);
            for (int c = 0; c < 4; c++)
                 Console.Write("\t"+"{0}"+"\t",zumValues[z, c]);
            Console.Write("\n");
        }
        Console.ReadLine();
    }
