    private MemoryStream createMemoryStream(DataTable[] tables, int[] divs)
            {
                MemoryStream ms = new MemoryStream();
                ExcelPackage pck = new ExcelPackage();
                for (int i = 0; i < tables.Length; i++)
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Division_" + divs[i].ToString());
                    ws.Cells["A1"].LoadFromDataTable(tables[i], true);
                }
                pck.SaveAs(ms);
                return ms;
            }
