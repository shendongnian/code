    private static string GetCellValue(SharedStringTablePart stringTablePart, DocumentFormat.OpenXml.Spreadsheet.Cell cell, DocumentFormat.OpenXml.Spreadsheet.Stylesheet styleSheet)
    {
        string value = cell.CellValue.InnerXml;
        if (cell.DataType != null && cell.DataType.Value == DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString)
        {
            return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
        }
        else
        {
            if (cell.StyleIndex != null)
            {
                DocumentFormat.OpenXml.Spreadsheet.CellFormat cellFormat = (DocumentFormat.OpenXml.Spreadsheet.CellFormat)styleSheet.CellFormats.ChildElements[(int)cell.StyleIndex.Value];
                    
                int formatId = (int)cellFormat.NumberFormatId.Value;
                if (formatId == 14) //[h]:mm:ss
                {
                    DateTime newDate = DateTime.FromOADate(double.Parse(value));
                    value = newDate.Date.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    //find the number format
                    NumberingFormat format = styleSheet.NumberingFormats.Elements<NumberingFormat>()
                                    .FirstOrDefault(n => n.NumberFormatId == formatId);
                    double temp;
                    if (format != null 
                        && format.FormatCode.HasValue 
                        && double.TryParse(value, out temp))
                    {
                        //we have a format and a value that can be represented as a double
                        string actualFormat = GetActualFormat(format.FormatCode, temp);
                        value = temp.ToString(actualFormat);
                    }
                }
            }
            return value;
        }
    }
    private static string GetActualFormat(StringValue formatCode, double value)
    {
        //the format is actually 4 formats split by a semi-colon
        //0 for positive, 1 for negative, 2 for zero (I'm ignoring the 4th format which is for text)
        string[] formatComponents = formatCode.Value.Split(';');
        int elementToUse = value > 0 ? 0 : (value < 0 ? 1 : 2);
        string actualFormat = formatComponents[elementToUse];
        actualFormat = RemoveUnwantedCharacters(actualFormat, '_');
        actualFormat = RemoveUnwantedCharacters(actualFormat, '*');
        //backslashes are an escape character it seems - I'm ignoring them
        return actualFormat.Replace("\"", ""); ;
    }
    private static string RemoveUnwantedCharacters(string excelFormat, char character)
    {
        /*  The _ and * characters are used to control lining up of characters
            they are followed by the character being manipulated so I'm ignoring
            both the _ and * and the character immediately following them.
            Note that this is buggy as I don't check for the preceeding
            backslash escape character which I probably should
            */
        int index = excelFormat.IndexOf(character);
        int occurance = 0;
        while (index != -1)
        {
            //replace the occurance at index using substring
            excelFormat = excelFormat.Substring(0, index) + excelFormat.Substring(index + 2);
            occurance++;
            index = excelFormat.IndexOf(character, index);
        }
        return excelFormat;
    }
