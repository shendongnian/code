    public void ExportToExcel(DataGridView dgv)
        {
            try
            {
                dgv.SelectAll();
                dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                DataObject doj = dgv.GetClipboardContent();
                Clipboard.SetDataObject(doj);
                dgv.ClearSelection();
                Microsoft.Office.Interop.Excel.Application exap = new Microsoft.Office.Interop.Excel.Application();
                exap.Visible = true;
                Workbook exwb = (Workbook)exap.Workbooks.Add();
                Worksheet exws = (Worksheet)exwb.Sheets["Sheet1"];
                exws.Paste();
                Clipboard.Clear();
                Range cell1 = exws.Cells[1, 2];
                Range cell2 = exws.Cells[dgv.Rows.Count + 1, dgv.ColumnCount + 1];
                Range cell3 = exws.Cells[1, dgv.ColumnCount + 1];
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
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
