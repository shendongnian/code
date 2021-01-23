       private static void ExtractImportLayoutFromExcelDt(DataTable importDt, DataTable dtExtracted, int languages)
        {
            // The number of Locale colums included in the excel file. 
            for (int x = 0; x < languages; x++)
            {
                // The total number of friendlynames-keys / language included in the excel.
                for (int j = 0; j < dtExtracted.Rows.Count; j++)
                {
                    AddRow(importDt, dtExtracted, dtExtracted.Rows[j], x+1);
                }
            }
        }
        private static void AddRow(DataTable table, DataTable dtExtracted, DataRow originalRow, int language)
        {
            var row = table.NewRow();
            row[0] = originalRow[0];
            row[1] = Regex.Match(dtExtracted.Columns[language].ToString(), @"\d+").Value;
            row[2] = originalRow[language];
            table.Rows.Add(row);
        }
