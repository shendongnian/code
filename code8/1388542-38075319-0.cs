            System.Data.DataSet dataSet1 = new System.Data.DataSet();
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            int index =1;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            //Get property collection and set selected property list
            PropertyInfo[] props = typeof(UsersExcel).GetProperties();
            List<PropertyInfo> propList = GenericListOutput.GetSelectedProperties(props, "", "");
            foreach (var prop in propList)
            {
                dt.Columns.Add(prop.Name);
                dic.Add(prop.Name, index++);
            }
            bool skipReadingHeaderRow = rows.MoveNext();
            while (rows.MoveNext())
            {
                try
                {
                    dynamic row;
                    if (rows.Current is HSSFRow)
                        row = (HSSFRow)rows.Current;
                    else
                        row = (XSSFRow)rows.Current;
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                            try
                            {
                                int j = -1;
                                dic.TryGetValue(i, out j);
                                if (cell == null && j > 0)
                                {
                                    dr[j - 1] = null;
                                }
                                else if (j > 0)
                                {
                                    switch (cell.CellType)
                                    {
                                        case CellType.Blank:
                                            dr[j - 1] = "[null]";
                                            break;
                                        case CellType.Boolean:
                                            dr[j - 1] = cell.BooleanCellValue;
                                            break;
                                        case CellType.Numeric:
                                            dr[j - 1] = cell.ToString();    //This is a trick to get the correct value of the cell. NumericCellValue will return a numeric value no matter the cell value is a date or a number.
                                            break;
                                        case CellType.String:
                                            dr[j - 1] = cell.StringCellValue;
                                            break;
                                        case CellType.Error:
                                            dr[j - 1] = cell.ErrorCellValue;
                                            break;
                                        case CellType.Formula:
                                        default:
                                            dr[j - 1] = "=" + cell.CellFormula;
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                    }
                   dt.Rows.Add(dr);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            dataSet1.Tables.Add(dt);
