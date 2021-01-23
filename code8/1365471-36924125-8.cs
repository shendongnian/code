            var cellValues = new List<string>();
            //var rowsCount = worksheet.UsedRange.Rows.Count;
            var columnRange = worksheet.UsedRange.Columns[1];
            bool first = true;
            foreach (var item in columnRange)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    foreach (var cellValue in item.Value)
                    {    
                        cellValues.Add(cellValue.ToString());    
                    }
                }
            }
    
            return cellValues;
