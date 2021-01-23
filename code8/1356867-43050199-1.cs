    private static string GetFormattedCellValue(WorkbookPart workbookPart, Cell cell)
        {
            if (cell == null)
            {
                return null;
            }
            string value = "";
            if (cell.DataType == null) // number & dates
            {
                int styleIndex = (int)cell.StyleIndex.Value;
                CellFormat cellFormat = (CellFormat)workbookPart.WorkbookStylesPart.Stylesheet.CellFormats.ElementAt(styleIndex);
                uint formatId = cellFormat.NumberFormatId.Value;
                
                if (formatId == (uint)Formats.DateShort || formatId == (uint)Formats.DateLong)
                {
                    double oaDate;
                    if (double.TryParse(cell.InnerText, out oaDate))
                    {
                        value = DateTime.FromOADate(oaDate).ToShortDateString();
                    }
                }
                else
                {
                    value = cell.InnerText;
                }
            }
            else // Shared string or boolean
            {
                switch (cell.DataType.Value)
                {
                    case CellValues.SharedString:
                        SharedStringItem ssi = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(cell.CellValue.InnerText));
                        value = ssi.Text.Text;
                        break;
                    case CellValues.Boolean:
                        value = cell.CellValue.InnerText == "0" ? "false" : "true";
                        break;
                    default:
                        value = cell.CellValue.InnerText;
                        break;
                }
            }
            return value;
        }
