            Excel.Worksheet activeWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            foreach (Excel.ListObject table in activeWorksheet.ListObjects)
            {
                Excel.Range tableRange = table.Range;
                String[] dataInRows = new string[tableRange.Rows.Count];
                int i = 0;
                foreach (Excel.Range row in tableRange.Rows)
                {
                    for (int j = 0; j < row.Columns.Count; j++)
                    {
                        if (row.Cells[1, j + 1].Value2 != null)
                        {
                            dataInRows[i] = dataInRows[i] + "_" + row.Cells[1, j + 1].Value2.ToString();
                        }
                    }
                    i++;
                }
            }
