    foreach (Cell c in r.Elements<Cell>())
    {
        string value = theCell.InnerText;
        if (c.DataType.Value == CellValues.SharedString)
        {
            var stringTable = worksheetPart.GetPartsOfType<SharedStringTablePart>()
                .FirstOrDefault();
            if (stringTable != null)
                value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
            text.Append(value + ",");
        }
        else
            text.Append(value + ",");
        text.AppendLine();
    }
