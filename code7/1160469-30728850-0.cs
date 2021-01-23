        Table table = new Table();     
        table.Rows.AddAt(3, FOAMTemplateGridview.HeaderRow);
        
                    foreach (GridViewRow row in FOAMTemplateGridview.Rows)
                    {
                        int index = 0;
                        table.Rows.Add(row);
                        foreach (TableCell tc in row.Cells)
                        {
                            switch (index)
                            {
        
                                case 0: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 1: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 2: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 3: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 4: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 5: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 6: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 7: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 8: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 9: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 10: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 11: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 12: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 13: tc.HorizontalAlign = HorizontalAlign.Right;
                                    break;
                                case 14: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 15: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                                case 16: tc.HorizontalAlign = HorizontalAlign.Left;
                                    break;
                            }
                            tc.Attributes.Add("class", "text");
                            tc.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
                            tc.BorderColor = Color.Black;
                            tc.Font.Name = "Arial";
                            tc.Font.Size = 10;
                            index++;
                        }
        
                    }
                StringWriter stw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(stw);
                hw.WriteLine(@"<style>.text { mso-number-format:\@; } </style>");
                table.RenderControl(hw);
    
                MailMessage newMail = new MailMessage();
                newMail.Priority = MailPriority.High;
                newMail.To.Add(foam.AomMail);
                newMail.Subject = "Subject";
                System.Text.Encoding Enc = System.Text.Encoding.ASCII;
                byte[] mBArray = Enc.GetBytes(stw.ToString());
                System.IO.MemoryStream mAtt = new System.IO.MemoryStream(mBArray, false);
                newMail.Attachments.Add(new Attachment(mAtt, "sales.xls"));  
  
