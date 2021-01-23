     public void writeCSV(DataGridView gridIn, string outputFile)
    {
        //test to see if the DataGridView has any rows
        if (gridIn.RowCount > 0)
        {
            string value = "";
            DataGridViewRow dr = new DataGridViewRow();
            StreamWriter swOut = new StreamWriter(outputFile);
            //write header rows to csv
            for (int i = 0; i <= gridIn.HeaderRow.Cells.Count - 1; i++)
            {
                if (i > 0)
                {
                    swOut.Write(",");
                }
                swOut.Write(gridIn.HeaderRow.Cells[i].HeaderText);
            }
            swOut.WriteLine();
            //write DataGridView rows to csv
            for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
            {
                if (j > 0)
                {
                    swOut.WriteLine();
                }
                dr = gridIn.Rows[j];
                for (int i = 0; i <= gridIn.HeaderRow.Cells.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    value = dr.Cells[i].Value.ToString();
                    //replace comma's with spaces
                    value = value.Replace(',', ' ');
                    //replace embedded newlines with spaces
                    value = value.Replace(Environment.NewLine, " ");
                    swOut.Write(value);
                }
            }
            swOut.Close();
        }
    }
