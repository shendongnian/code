    private void btn_Add_Click(object sender, EventArgs e)
            {
                try
                {
                    String name = tb_Name.Text;
                    DateTime dob = dtp_dob.Value.Date;
                    int age = Convert.ToInt32(tb_Age.Text);
                    String Address = tb_Address.Text;
                    int telno = Convert.ToInt32(tb_Telno.Text);
                    int line = 0;
    
                  
                    query = "Insert into tb_Student values('"+ name +"','"+ dob +"','"+ age +"','"+ Address +"','"+ telno +"')";
                    
                    MessageBox.Show(query); //To see it works!
                   
                    line = dc.ExeNonQuery(query);
                    
                    if (line > 0)
                    {
                        loadGridData();
                        ClearData();
                        MessageBox.Show("Data saved sucessfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Data not Saved", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            } 
