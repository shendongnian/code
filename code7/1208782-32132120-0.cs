           string value; 
           if (isDecimal(dsrow[col].ToString()))
            {
                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                value = dsrow[col].ToString()
            }
            else
            {
                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                value = dsrow[col].ToString().Replace(System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator, ".");
                // Or simply
                // value = dsrow[col].ToString().Replace(",", ".");
            }
            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(value);
