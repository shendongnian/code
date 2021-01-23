    public static void ApplyAutofilter(string fileName, string sheetName, string reference)
    {
        using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
        {
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);
            var arrSheets = sheets as Sheet[] ?? sheets.ToArray();
            string relationshipId = arrSheets.First().Id.Value;
            var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
            var autoFilter = new AutoFilter() { Reference = reference };
            OpenXmlElement preceedingElement = GetPreceedingElement(worksheetPart);
            worksheetPart.Worksheet.InsertAfter(autoFilter, preceedingElement);
            worksheetPart.Worksheet.Save();
        }
    }
    
    public static OpenXmlElement GetPreceedingElement(WorksheetPart worksheetPart)
    {
        List<Type> elements = new List<Type>()
        {
            typeof(Scenarios),
            typeof(ProtectedRanges),
            typeof(SheetProtection),
            typeof(SheetCalculationProperties),
            typeof(SheetData)
        };
        OpenXmlElement preceedingElement = null;
        foreach (var item in worksheetPart.Worksheet.ChildElements.Reverse())
        {
            if (elements.Contains(item.GetType()))
            {
                preceedingElement = item;
                break;
            }
        }
        return preceedingElement;
    }
