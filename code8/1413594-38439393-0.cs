        public static void ExtractImportLayoutFromExcelDt(DataTable importDt, DataTable dtExtracted, int languages)
        {
            Enumerable.Range(0, languages)
                .ToList().ForEach(x =>
                {
                    Enumerable.Range(0, dtExtracted.Rows.Count)
                        .ToList().ForEach(j =>
                        {
                            var row = dtExtracted.Rows[j];
                            DataRow tempRow = importDt.NewRow();
                            AddRow(importDt, dtExtracted, x, row, tempRow);
                        });
                });
        }
        private static void AddRow(DataTable importDt, DataTable dtExtracted, int x, DataRow row, DataRow tempRow)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (i == 0)
                {
                    tempRow[i] = row[i];     // Friendly names: This is always going to be column 1 [0].                          
                }
                else if (i == 1)
                {
                    tempRow[i] = Regex.Match(dtExtracted.Columns[x + 1].ToString(), @"\d+").Value; // LocaleIDs: Getting rid of non numeric characters from this column.
                }
                else
                {
                    tempRow[i] = row[x + 1];
                }
            }
            importDt.Rows.Add(tempRow);
        }
