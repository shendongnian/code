      private async void btn_WriteIntoWord_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc; 
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                
                object missing = System.Reflection.Missing.Value;
                lblProcessing.Text = "Writing File.. Please wait";
                int count=0;
               
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    doc = app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    doc.Content.Font.Size = 12;
                    doc.Content.Font.Bold = 1;
                    if (count != 0) doc.Content.Text = "Dear Team,";
                    int innercount = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        innercount++;
                        
                        if (count != 0)
                        {
                            if (cell.Value != null)
                            {
                                
                                await Task.Delay(1);
                                string value = cell.Value.ToString();
                                switch(innercount)
                                {
                                    case 1:
                                         doc.Content.Text += "          EC Name: " + value;
                                        break;
                                    case 2:
                                         doc.Content.Text += "          SO#: " + value;
                                        break;
                                    case 3:
                                        doc.Content.Text += "           Monthly Hire Rate: " + value.Trim();
                                        break;
                                    case 4:
                                        doc.Content.Text += "           Bill amount: " + value.Trim();
                                        break;
                                    case 5:
                                        doc.Content.Text += "           Project code: " + value;
                                        break;
                                    case 6:
                                        doc.Content.Text += "           Line Text: " + value;
                                        break;
                                    case 7:
                                        doc.Content.Text += "           Total WD: " + value;
                                        break;
                                    case 8:
                                        doc.Content.Text += "           #NPL: " + value;
                                        break;
                                    case 9:
                                        doc.Content.Text += "           Project%: " + value;
                                        break;
                                    case 10:
                                        doc.Content.Text += "           Remark: " + value;
                                        break;
                                    case 11:
                                        doc.Content.Text += "           ALCON Emp ID: " + value;
                                        break;
                                    default:
                                        doc.Content.Text += value;
                                        break;
                                }
                               
                            }
                          
                        }
                    }
                   
                    if (count != 0)
                    {
                        doc.Content.Text += "Thanks,";
                        doc.Content.Text += "NCS team";
                        string filecount = "test" + count.ToString() + ".docx";
                        object filename = @"D:\GenerateEmail\EmailBillingRates\EmailBillingRates\Word\" + filecount;
                        doc.SaveAs2(ref filename);
                        doc.Save();
                        doc.Close();
                    }
                    if (count == 10)
                        break;
                    count++;
                }
                app.Visible = true;    //Optional
               
                lblProcessing.Text = "";
               // MessageBox.Show("File Saved successfully");
                this.Close();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.ReleaseComObject(app);
            }
        }
    }
