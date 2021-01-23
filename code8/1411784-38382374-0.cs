    public void Write2Sheet(DataTable dt1, DataTable dt2, DataTable dt3, String newFilePath)
        {
            try
            {
                //Merge the three Datatables into the single Datatable source  
                //method syntax
                var mdata = facilData.AsEnumerable().Where(f => f[0] != typeof(DBNull)).Join(ownerData.AsEnumerable(),
                            table1 => table1.Field<int>(0),
                            table2 => table2.Field<int>(0),
                            (table1, table2) => new Class1   //container class
                            {
                                rowIndex = (int)table1[0],
                                Prog = table1[1].ToString(),
                                cStatus = table1[2].ToString(),
                                bStatus = table1[3].ToString(),
                                fID = table1[4].ToString(),
                                fNam = table1[5].ToString(),
                                fAdd = table1[6].ToString(),
                                fCity = table1[7].ToString(),
                                fState = table1[8].ToString(),
                                fCode = table1[9].ToString(),
                                oInfo = table2[1].ToString(),
                                pgRecId = table1[10].ToString(),
                                lAct = table1[11].ToString()
                            });
                foreach (var rec in mdata)
                {
                    var row = dataStore.NewRow();
                    row["rowIndex"] = rec.rowIndex;
                    row["Prog"] = rec.Prog;
                    row["cStatus"] = rec.cStatus;
                    row["bStatus"] = rec.bStatus;
                    row["fID"] = rec.fID;
                    row["fNam"] = rec.fNam;
                    row["fAdd"] = rec.fAdd;
                    row["fCity"] = rec.fCity;
                    row["fState"] = rec.fState;
                    row["fCode"] = rec.fCode;
                    row["oInfo"] = rec.oInfo;
                    row["pgRecId"] = rec.pgRecId;
                    row["lAct"] = rec.lAct;
                    dataStore.Rows.Add(row);
                }
            }
            catch (Exception e)
            {
                Write2LogFile("The data tables couldn't merge because: " + e.Message);
            }
            //Write from the Datatable source to the new spreadsheet and save it
            try
            {
                FileInfo newSheet = new FileInfo(fileName);
                using (ExcelPackage xPkg = new ExcelPackage(newSheet))
                {
                    ExcelWorksheet worksheet = xPkg.Workbook.Worksheets[1];
                    var cell = worksheet.Cells;
                    int rI = 2;
                    foreach (DataRow dr in dataStore.Rows)
                    {
                        string iDX = rI.ToString();
                        worksheet.Cells["A" + iDX].Value = dr["Prog"].ToString();
                        worksheet.Cells["B" + iDX].Value = dr["cStatus"].ToString();
                        worksheet.Cells["C" + iDX].Value = dr["bStatus"].ToString();
                        worksheet.Cells["D" + iDX].Value = dr["fID"].ToString();
                        worksheet.Cells["E" + iDX].Value = dr["fNam"].ToString();
                        worksheet.Cells["F" + iDX].Value = dr["fAdd"].ToString();
                        worksheet.Cells["G" + iDX].Value = dr["fCity"].ToString();
                        worksheet.Cells["H" + iDX].Value = dr["fState"].ToString();
                        worksheet.Cells["I" + iDX].Value = dr["fCode"].ToString();
                        worksheet.Cells["J" + iDX].Value = dr["oInfo"].ToString();
                        worksheet.Cells["K" + iDX].Value = dr["pgRecId"].ToString();
                        worksheet.Cells["L" + iDX].Value = dr["lAct"].ToString();
                        rI++;
                    }
                    xPkg.Save();
                    MessageBox.Show("Data was successfully added to the current spreadsheet.");
                }
            }
            catch (Exception ex)
            {
                Write2LogFile("Data was not written to spreadsheet because: " + ex.Message);
            }
        }
