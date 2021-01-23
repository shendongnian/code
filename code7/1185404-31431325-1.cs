        using XLS = Microsoft.Office.Interop.Excel;
    
             /// <summary>
        /// Gets the range header caption of a given range.
        /// The methode goes through every previous cell of the given range to determine the caption.
        /// If the caption can not be determined the method returns an random string.
        /// </summary>
        /// <param name="selectedRange">The selected range.</param>
        /// <returns></returns>
        public static string GetRangeHeaderCaption(Range selectedRange, XLS._Application excelApp)
        {
            // The caption of the range. The default value is a random string
            var rangeCaption = ExcelHelper.getRandomString(5);
            // Check if the provided range is valid
            if (selectedRange != null && excelApp.WorksheetFunction.CountA(selectedRange) > 0)
            {
                // Get the included cells of the range
                var rangeCells = selectedRange.Address.Split(new char[] { ':' });
                // Get the beginning cell of the range
                var beginCell = rangeCells[0].Trim();
                // Get the column and row data of the cell
                var cellColumnRow = beginCell.Split(new char[] { '$' });
                // Split the beginning cell into the column and the row
                var cellColumn = cellColumnRow[1];
                var cellRow = Convert.ToInt32(cellColumnRow[2]);
                var captionNotFound = true;
                int i = 0;
                // Go to each previous cell of the provided range 
                // to determine the caption of the range            
                do
                {
                    // Check if the next cell would be invalid
                    var nextCellRow = cellRow - i;
                    if (nextCellRow == 0)
                        break;
                    // Create the cell coordinates to look at
                    var cellToLook = string.Format("{0}{1}",
                                                    cellColumn,
                                                    nextCellRow);
                    // Get the value out of the cell
                    var cellRangeValue = ((XLS.Worksheet)((XLS.Workbook)excelApp.ActiveWorkbook).ActiveSheet).get_Range(cellToLook).Value;
                    // ...just to be sure it does not crash
                    if (cellRangeValue != null)
                    {
                        // Convert the determined value to an string
                        var cellValue = cellRangeValue.ToString();
                        double value;
                        // Check if the cell value is not a numeric value
                        // Check if the cell value is not empty or null
                        if (!double.TryParse(cellValue, out value) &&
                            !string.IsNullOrWhiteSpace(cellValue) &&
                            !string.IsNullOrEmpty(cellValue))
                        {
                            // In this case we found the caption
                            rangeCaption = cellValue;
                            captionNotFound = false;
                        }
                    }
                    i++;
                } while (captionNotFound);
            }
            return rangeCaption;
        }
