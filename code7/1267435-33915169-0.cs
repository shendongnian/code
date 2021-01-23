    public static void CreateWorkbook(String filePath, DataSet dataset)
        {
            if (dataset.Tables.Count == 0)
                throw new ArgumentException("DataSet needs to have at least one DataTable", "dataset");
    
            Workbook workbook = new Workbook();
            foreach (DataTable dt in dataset.Tables)
            {
                Worksheet worksheet = new Worksheet(dt.TableName);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    // Add column header
                    worksheet.Cells[0, i] = new Cell(dt.Columns[i].ColumnName);
    
                    // Populate row data
                    for (int j = 0; j < dt.Rows.Count; j++)
                        worksheet.Cells[j + 1, i] = new Cell(dt.Rows[j][i]);
                }
                workbook.Worksheets.Add(worksheet);
            }
            workbook.Save(filePath);
        }
