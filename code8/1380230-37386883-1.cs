    foreach (TableRow tr in tbl.Rows)
            {
                string str_Confirmed = string.Empty;
                string str_Description = string.Empty;
                string str_Reason = string.Empty;
                foreach (TableCell tc in tr.Cells)
                {
                    if (tc.Controls.Count > 0)
                    {
                        if (tc.Controls[0] is CheckBox)
                        {
                            if (((CheckBox)tc.Controls[0]).Checked == true)
                            {
                                str_Confirmed = "Y";
                            }
                            else
                            {
                                str_Confirmed = "N";
                            }
                        }
                        else if (tc.Controls[0] is Label)
                        {
                            string txt = string.Empty;
                            str_Description = ((Label)tc.Controls[1]).Text;
                        }
                        else if (tc.Controls[0] is TextBox)
                        {
                            str_Reason = ((TextBox)tc.Controls[2]).Text;
                            //Response.Write(((TextBox)tc.Controls[0]).Text);
                        }
                    }
                }
            }
