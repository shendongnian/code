    public static void WriteToFile()
    {
        var stringBuilder = new StringBuilder();
    
        foreach (var arrayElement in arrayOfIntNumbers)
        {
            stringBuilder.AppendLine(arrayElement.ToString());
        }
    
        File.AppendAllText(@"yourPathOfTheFile\array.txt", stringBuilder.ToString());
    }
