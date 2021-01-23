    public void ExporttoExcel(System.Data.DataTable dtbl)
        {
            StringBuilder Output = new StringBuilder();
            //The first "line" will be the Headers.
            for (int i = 0; i < dtbl.Columns.Count; i++)
            {
                Output.Append(dtbl.Columns[i].ColumnName + "\t");
            }
            Output.Append("\n");
            //Generate Cell Value Data
            foreach (DataRow Row in dtbl.Rows)
            {
                if (Row.RowState != DataRowState.Deleted)
                {
                    for (int i = 0; i < Row.ItemArray.Length; i++)
                    {
                        //Handling the last cell of the line.
                        if (i == (Row.ItemArray.Length - 1))
                        {
                            Output.Append(Row.ItemArray[i].ToString() + "\n");
                        }
                        else
                        {
                            Output.Append(Row.ItemArray[i].ToString() + "\t");
                        }
                    }
                }
            }
            Clipboard.SetText(Output.ToString());
            Microsoft.Office.Interop.Excel.Application exap = new Microsoft.Office.Interop.Excel.Application();
            exap.Visible = true;
            Workbook exwb = (Workbook)exap.Workbooks.Add();
            Worksheet exws = (Worksheet)exwb.Sheets["Sheet1"];
            exws.Paste();
            Clipboard.Clear();
            Range cell1 = exws.Cells[1, 1];
            Range cell2 = exws.Cells[dtbl.Rows.Count, dtbl.Columns.Count];
            Range cell3 = exws.Cells[1, dtbl.Columns.Count];
            Range range = exws.get_Range(cell1, cell2);
            Range colorrange = exws.get_Range(cell1, cell3);
            range.Borders.Weight = XlBorderWeight.xlThin;
            colorrange.Interior.Color = System.Drawing.Color.SteelBlue;
            colorrange.Font.Color = System.Drawing.Color.White;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel File 2010 (*.xlsx)|*.xlsx|Excel File 2003 (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                exwb.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
