     var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet ds = dataGridView1.DataSource as DataSet;
                    if (ds != null)
                    {
                        DataTable tbl = ds.Tables["hostes_tablo"];
                        FileInfo file = new FileInfo(saveFileDialog1.FileName);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                        using (ExcelPackage pck = new ExcelPackage(file))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("AjansRed Sorgu Sonuç");
                            ws.Cells["A1"].LoadFromDataTable(tbl, true);
                            ws.Cells.AutoFitColumns();
                            ws.Cells[1,dataGridView1.Columns.Count+2].Value = label81.Text.ToString();
                            using (ExcelRange rng = ws.Cells[1, 1, 1, dataGridView1.Columns.Count+1])//ws.cells[from row, from column, to row, to column]. sayıların anlamı
                            {
                                rng.Style.Font.Bold = true;
                                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }
                            pck.Save();
                            pck.Dispose();
                        }
                        MessageBox.Show(string.Format(@"Sorgu Sonucunuzu İçeren  ""{0}"" Başarıyla Dışarıya Aktarıldı!", file.Name));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata! Hata! Hata! Excel Dışarı Aktarma Esnasında Sorun Oluştu. Original error: " + ex.Message);
                }
            }
