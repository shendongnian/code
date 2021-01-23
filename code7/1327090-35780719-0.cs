    public static string NameGen()
    {
        int index = random.Next(Names.Length);
        return Names[index];
    }
    public static string SurnameGen()
    {
        int index = random.Next(Surnames.Length);
        return Surnames[index];
    }
