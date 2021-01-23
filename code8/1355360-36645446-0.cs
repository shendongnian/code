                public void EmailCurrMonthSummary()
                        {
                            DataAccess da = new DataAccess();
                            MonthEndSummary mes = new MonthEndSummary();
                            DataTable tempTable = new DataTable();
                            mes.MonthEndSummaryTable = da.GetCurrMonthSummary(); //returns a DataTable                    
    
                            MailMessage mail = new MailMessage();
                            mail.To.Add("User@xxx.com");
                            mail.From = new MailAddress("Sender@xxx.com");
                            mail.Body = "Hello World";
                            mail.Subject = "Month End Status";
    System.IO.MemoryStream str = DataToExcel(mes.MonthEndSummaryTable);
    
                Attachment at = new Attachment(str, "MonthEndSummary.xls");
                mail.Attachments.Add(at);    
                            mail.IsBodyHtml = true;
    
                            SmtpClient smtp = new System.Net.Mail.SmtpClient();
                            smtp.UseDefaultCredentials = true;
                            smtp.Send(mail);
                        }
    
    
     public System.IO.MemoryStream DataToExcel(DataTable dt)
            {
                //StreamWriter sw = new StreamWriter();
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                if (dt.Rows.Count > 0)
                {
    
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentEncoding = System.Text.Encoding.Default;
    
                }
                System.IO.MemoryStream s = new MemoryStream();
                System.Text.Encoding Enc = System.Text.Encoding.Default;
                byte[] mBArray = Enc.GetBytes(tw.ToString());
                s = new MemoryStream(mBArray, false);
                  
                return s;
            }
