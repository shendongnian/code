    public void xlsEpplus()
        {
            try
            {
                TimeSpan stop;
                TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
                Database DB = new Database();
                DB.msConect();
                string sql = "SELECT * FROM table_test";
                DataTable dt_tab = DB.xSqlMs(sql);
                string Template = "D:\\Plantillas\\Template.xlsx";
                string filePath = "D:\\Plantillas\\Report_with_Epplus.xlsx";
                File.Copy(Template, filePath, true);
                ExcelPackage pck = new ExcelPackage();
                pck.Load(new FileStream(Template, FileMode.OpenOrCreate));
                ExcelWorksheet ws = pck.Workbook.Worksheets.First();
                var a = ws.Cells["A1"].Value;
                int i = 2;
                ws.InsertRow(i, dt_tab.Rows.Count);
                ws.Cells["A2"].LoadFromDataTable(dt_tab, true);
                pck.SaveAs(new FileInfo(filePath));
                stop = new TimeSpan(DateTime.Now.Ticks);
                Console.WriteLine("xlsEpplus_While:" + stop.Subtract(start));
            }
            catch (Exception ex)
            {
                //
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
