    foreach (Cell c in r.Elements<Cell>())
    {
        string value = c.InnerText;
        if (c.DataType.Value == CellValues.SharedString)
        {
            var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>()
                .FirstOrDefault();
            if (stringTable != null)
                value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
            text.Append(value + ",");
        }
        else
            text.Append(value + ",");
        text.AppendLine();
    }
