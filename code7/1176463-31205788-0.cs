    while (reader.Read())
    {
        if (reader.ElementType == typeof(CellValue)
            && reader.IsStartElement)
        {
            text = reader.GetText();
            Console.WriteLine(text + " ");
        }
    }
