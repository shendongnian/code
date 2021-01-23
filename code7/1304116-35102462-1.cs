        public void ExcelBtn_Click(object sender, EventArgs e)
        {
            DataSet dst = PrepareData();
            byte[] bytes = ExportDataSetToExcel(dst);
            Response.ClearContent();
            Response.ContentType = "application/msoffice";
            Response.AddHeader("Content-Disposition", @"attachment; filename=""ExportedExcel.xlsx"" ");
            Response.BinaryWrite(bytes);
            Response.End();
        }
        public static DataSet PrepareData()
        {
            DataTable badBoysDst = new DataTable("BadBoys");
            badBoysDst.Columns.Add("Nr");
            badBoysDst.Columns.Add("Name");
            badBoysDst.Rows.Add(1, "Me");
            badBoysDst.Rows.Add(2, "You");
            badBoysDst.Rows.Add(3, "Pepe");
            badBoysDst.Rows.Add(4, "Roni");
            //Create a Department Table
            DataTable goodBoysDst = new DataTable("GoodBoys");
            goodBoysDst.Columns.Add("Nr");
            goodBoysDst.Columns.Add("Name");
            goodBoysDst.Rows.Add("1", "Not me");
            goodBoysDst.Rows.Add("2", "Not you");
            goodBoysDst.Rows.Add("3", "Quattro");
            goodBoysDst.Rows.Add("4", "Stagioni");
            DataTable goodBoysDst2 = new DataTable("GoodBoys2");
            goodBoysDst2.Columns.Add("Nr");
            goodBoysDst2.Columns.Add("Name");
            goodBoysDst2.Rows.Add("1", "Not me");
            goodBoysDst2.Rows.Add("2", "Not you");
            goodBoysDst2.Rows.Add("3", "Quattro");
            goodBoysDst2.Rows.Add("4", "Stagioni");
            DataTable goodBoysDst3 = new DataTable("GoodBoys3");
            goodBoysDst3.Columns.Add("Nr");
            goodBoysDst3.Columns.Add("Name");
            goodBoysDst3.Rows.Add("1", "Not me");
            goodBoysDst3.Rows.Add("2", "Not you");
            goodBoysDst3.Rows.Add("3", "Quattro");
            goodBoysDst3.Rows.Add("4", "Stagioni");
            //Create a DataSet with the existing DataTables
            DataSet dst = new DataSet("SchoolBoys");
            dst.Tables.Add(badBoysDst);
            dst.Tables.Add(goodBoysDst);
            dst.Tables.Add(goodBoysDst2);
            dst.Tables.Add(goodBoysDst3);
            return dst;
        }
        public static byte[] ExportDataSetToExcel(DataSet dst)
        {
            #region Create The Excel
            Excel.Application excelApp = null;
            Excel.Workbook excelWorkBook = null;
            try
            {
                excelApp = new Excel.Application();
                if (excelApp == null)
                    throw new Exception("You can throw custom exception here too");
                excelWorkBook = excelApp.Workbooks.Add();
                int sheetNr = 1;
                foreach (DataTable table in dst.Tables)
                {
                    Excel.Worksheet excelWorkSheet = null;
                    //Add a new worksheet or reuse first 3 sheets of workbook with the Datatable name
                    if (sheetNr <= excelWorkBook.Sheets.Count)
                    {
                        excelWorkSheet = excelWorkBook.Sheets.get_Item(sheetNr);
                    }
                    else
                    {
                        excelWorkSheet = excelWorkBook.Sheets.Add(After: excelWorkBook.Sheets[excelWorkBook.Sheets.Count]);
                    }
                    excelWorkSheet.Name = table.TableName;
                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                    sheetNr += 1;
                }
                //make first sheet active
                excelApp.ActiveWorkbook.Sheets[1].Select();
                excelWorkBook.SaveAs(@"c:\temp\DataSetToExcel.xlsx");
                
            }
            finally
            {
                excelWorkBook.Close();
                excelApp.Quit();
            }
            #endregion
            #region Take byte[] of the excel
            byte[] result = null;
            using (FileStream fs = new FileStream(@"c:\temp\DataSetToExcel.xlsx", FileMode.Open, FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(fs);
                result = reader.ReadBytes((int)fs.Length);
            }
            #endregion
            #region Delete the excel from the server
            File.Delete(@"c:\temp\DataSetToExcel.xlsx");
            #endregion
            return result;
        }
    }
