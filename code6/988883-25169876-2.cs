    var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
    if (stringTable != null)
    {
        sharedString = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
    }
