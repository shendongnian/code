    try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT Max(RegistrationNo) from tbl_StudentRegNo where (RegistrationNo Like'%" + lblshortcode.Text + "%')";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lbllastregno.Text = (rdr[0]).ToString();
                        string lastregno = lbllastregno.Text;
                        if(rdr[0]!=DBNull.Value)
                        {
                            string current_serial_no = lastregno.Substring(lastregno.Length - 4, 4);
                            lblcurrentsno.Text = current_serial_no;
                            int next_serial_no = Convert.ToInt32(current_serial_no) + 1;
                            lblnextsno.Text = next_serial_no.ToString("0000");
                        }
                        else
                        {
                            lbllastregno.Text = reg_no + lblshortcode.Text + lbldigitformat.Text;
                        }
                         
                    }
                }
                else
                {
                    lbllastregno.Text = reg_no + lblshortcode.Text + lbldigitformat.Text;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
