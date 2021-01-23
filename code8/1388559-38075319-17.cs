         public DataTable GetExcelDataTable(NPOI.SS.UserModel.IWorkbook hssfworkbook, int rowCount)
        {
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            bool skipReadingHeaderRow = rows.MoveNext();
            if (skipReadingHeaderRow)
            {
                dynamic row;
                if (rows.Current is NPOI.HSSF.UserModel.HSSFRow)
                    row = (NPOI.HSSF.UserModel.HSSFRow)rows.Current;
                else
                    row = (NPOI.XSSF.UserModel.XSSFRow)rows.Current;
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell != null)
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                    else
                    {
                        dt.Columns.Add(string.Empty);
                    }
                }
            }
            int cnt = 0;
            while (rows.MoveNext() && cnt < rowCount)
            {
                cnt++;
                dynamic row;
                if (rows.Current is NPOI.HSSF.UserModel.HSSFRow)
                    row = (HSSFRow)rows.Current;
                else
                    row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null && i > 0)
                    {
                        dr[i - 1] = null;
                    }
                    else if (i > 0)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.Blank:
                                dr[i - 1] = "[null]";
                                break;
                            case CellType.Boolean:
                                dr[i - 1] = cell.BooleanCellValue;
                                break;
                            case CellType.Numeric:
                                dr[i - 1] = cell.ToString();
                                break;
                            case CellType.String:
                                dr[i - 1] = cell.StringCellValue;
                                break;
                            case CellType.Error:
                                dr[i - 1] = cell.ErrorCellValue;
                                break;
                            case CellType.Formula:
                            default:
                                dr[i - 1] = "=" + cell.CellFormula;
                                break;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
