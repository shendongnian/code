    private static string GetCellValue(SpreadsheetDocument doc, Cell cell)
    {
        // if no dataType, return the value of the innerText of the cell
        if (cell.DataType == null) return cell.InnerText;
        // depending type of the cell
        switch (cell.DataType.Value)
        {
            // string => search for CellValue
            case CellValues.String:
                return cell.CellValue != null ? cell.CellValue.Text : string.Empty;
            // inlineString => search of InlineString
            case CellValues.InlineString:
                return cell.InlineString != null ? cell.InlineString.Text.Text : string.Empty;
            // sharedString => search for the SharedString
            case CellValues.SharedString:
                // is sharedPart exist ?
                if (doc.WorkbookPart.SharedStringTablePart == null) doc.WorkbookPart.SharedStringTablePart = new SharedStringTablePart();
                // is the text exist ?
                foreach (SharedStringItem item in doc.WorkbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>())
                {
                    // the text exist, return it from SharedStringTable
                    if (item.InnerText == cell.InnerText) return cell.InnerText;
                }
                // no text in sharedStringTable, create it and return it
                doc.WorkbookPart.SharedStringTablePart.SharedStringTable.Append(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(cell.InnerText)));
                doc.WorkbookPart.SharedStringTablePart.SharedStringTable.Save();
                return cell.InnerText;
            // default case : bool / number / date
            // return the value of the cell in plain text
            // you can parse types depending your needs
            default:
                return cell.InnerText;
        }
    }
