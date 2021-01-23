    public DataTable GetExcelDataTable(NPOI.SS.UserModel.IWorkbook hssfworkbook, int rowCount)
        {
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            bool skipReadingHeaderRow = rows.MoveNext();
            int cnt = 0;
            while (rows.MoveNext() && cnt < rowCount)
            {
                cnt++;
                dynamic row;
                if (rows.Current is NPOI.HSSF.UserModel.HSSFRow)
                    row = (NPOI.HSSF.UserModel.HSSFRow)rows.Current;
                else
                    row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i - 1] = null;
                    }
                    else if (i > 0)
                    {
                        dr[i - 1] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
