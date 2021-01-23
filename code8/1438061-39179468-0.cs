    private void saverec_Click(object sender, EventArgs e)
            {
                try
                {
                    int recna = Convert.ToInt32(recno_tb.Text);
                    OleDbConnection myconn = new OleDbConnection();
                    myconn.ConnectionString = connestr;
                    var insequ = "INSERT INTO FormEntry (ImageName, RecordNo, EmailId) VALUES (?,?,?)";
                    OleDbCommand dtcmd = new OleDbCommand(insequ, myconn);
                    dtcmd.Parameters.AddWithValue("@imagena", OleDbType.VarChar).Value = imgname_tb.Text;
                    dtcmd.Parameters.AddWithValue("@recno", OleDbType.Integer).Value = recna;
                    dtcmd.Parameters.AddWithValue("@email", OleDbType.VarChar).Value = email_tb.Text;
                    myconn.Open();
                    dtcmd.ExecuteNonQuery();
                    myconn.Close();
                    dataconnect();
                    addnew_Click(sender, e);
                    recno_tb.Text = (recna + 1).ToString();
                    email_tb.Focus();
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToString() == "The changes you requested to the table were not successful because they would create duplicate values in the index, primary key, or relationship.  Change the data in the field or fields that contain duplicate data, remove the index, or redefine the index to permit duplicate entries and try again.")
                    {
                        MessageBox.Show("Record already exists. Try entering new record.\nYou can also find and edit the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Message.ToString() == "Field 'FormEntry.RecordNo' cannot be a zero-length string.")
                    {
                        MessageBox.Show("Record No can't be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                myconn.Close();
    
            }
