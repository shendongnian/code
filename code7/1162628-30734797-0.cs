    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    
    namespace X
    {
        class CreateExcelDoc
        {
            private Microsoft.Office.Interop.Excel.Application app = null;
            private Microsoft.Office.Interop.Excel.Workbook workbook = null;
            private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            private Microsoft.Office.Interop.Excel.Range workSheet_range = null;
    
            public void DisposeAll()
            {
                app = null;
                workbook = null;
                worksheet = null;
                workSheet_range = null;
    
                GC.Collect();
            }
    
            public void CreateDoc()
            {
                try
                {
                    app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    workbook = app.Workbooks.Add(1);
                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
    
                    SetSheetStyle();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error : " + e.Message);
                }
                finally
                {
                }
            }
    
            private void SetSheetStyle()
            {
                worksheet.Range["A1", "Z1000"].Style.Font.Name = "Arial";
                worksheet.Range["A1", "Z1000"].Style.Font.Size = 10;
                worksheet.Range["A1", "J1000"].Style.Font.Bold = true;
            }
    
            public void AddHeaders()
            {
                addData(1, 1, "A");
                addData(1, 2, "B");
                addData(1, 3, "C");
            }
    
            public void AddCell(int row, int col, object data)
            {
                if (data == null)
                    return;
    
                try
                {
                    if (data is string && (string)data != "EOF")
                        worksheet.Cells[row, col] = (string)data;
                    else if (data is double)
                        worksheet.Cells[row, col] = (double)data;
                    else if (data is long)
                        worksheet.Cells[row, col] = (long)data;
                    else if (data is decimal)
                        worksheet.Cells[row, col] = (decimal)data;
                    else throw new Exception("type unsupported");
                }
                catch(Exception e)
                {
                    MessageBox.Show("write error(unsupported" format ?)\n" + e.Message);
                }
            }
    
            public void addData(int row, int col, string data,
                string cell1, string cell2, string format)
            {
                worksheet.Cells[row, col] = data;
                workSheet_range = worksheet.get_Range(cell1, cell2);
                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheet_range.NumberFormat = format;
            }
    
            public void addData(int row, int col, string data)
            {
                try
                {
                    string cell = ((char)(64 + col)).ToString() + row.ToString();
    
                    int n;
                    bool isNumeric = int.TryParse("123", out n);
                    string format = (isNumeric == true) ? "#,##0" : "";
    
                    addData(row, col, data, cell, cell, format);
                }
                catch (Exception e)
                {
                    Form1.BallonInfo(e.Message);
                }
            }
        }
    }
