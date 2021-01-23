    // First add a text column.
    DataGridTextColumn textColumn = new DataGridTextColumn();
    textColumn.Header = "Babylon and Ting";
    dgOutput.Columns.Add(textColumn);
    string[] raw_text = System.IO.File.ReadAllLines("c:\\temp\\import.csv");
    string[] data_col = null;
    int x = 0;
    foreach (string text_line in raw_text)
    {
        data_col = text_line.Split(',');
        if (x == 0)
        {
            for(int i =0; i <= data_col.Count() -1; i++)
            {
                // Then add rows to the datagrid.
                dgOutput.Items.Add(data_col[i]);
            }
        }
        else
        {
        }
    }
