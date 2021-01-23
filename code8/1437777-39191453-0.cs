            Microsoft.Office.Interop.Excel.Worksheet ws;
            try
            {
                Microsoft.Office.Interop.Excel.Application Excell = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = Excell.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                ws = (Microsoft.Office.Interop.Excel.Worksheet)Excell.ActiveSheet;
                Excell.Visible = true;
            }
            catch (Exception)
            {
                return;
            }
            int i = 1;
            foreach (DataGridViewColumn clm in dgw.Columns)
            {
                ws.Cells[2, i] = clm.Name;
                Microsoft.Office.Interop.Excel.Range xcell = ws.Cells[2, i];
                Microsoft.Office.Interop.Excel.Borders brd1 = xcell.Borders;
                xcell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                brd1.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                brd1.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                i++;
            }
            Microsoft.Office.Interop.Excel.Range row = ws.Cells[2, i];
            row.EntireRow.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range fcell = ws.Cells[1, 1];
            Microsoft.Office.Interop.Excel.Range lcell = ws.Cells[1, i - 1];
            Microsoft.Office.Interop.Excel.Range space = ws.get_Range(fcell, lcell);
            space.Merge(true);
            space.EntireRow.Font.Bold = true;
            ws.Cells[1, 1] = //Your text here
            Microsoft.Office.Interop.Excel.Borders brd = space.Borders;
            aralik.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            int m = 3;
            foreach (DataGridViewRow rows in dgw.Rows)
            {
                for (int p = 1; p < i; p++)
                {
                    if (rows.Cells[p-1].Value.ToString()=="")
                    {
                        string str = string.Empty;
                        foreach (Control item in cList)
                        {
                            if (item.Name=="lbl_"+(rows.Index.ToString())+"_"+((p-1).ToString()))
                            {
                                str = item.Text;
                                ws.Cells[m, p] = str;
                            }
                        }
                    }
                    else
                    {
                        ws.Cells[m, p] = rows.Cells[p - 1].Value;
                    }
                }
                m++;
            }
            ws.Columns.AutoFit();
