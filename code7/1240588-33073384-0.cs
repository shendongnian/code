        con.Open();
                    OleDbCommand dt = new OleDbCommand("UPDATE  AccRec SET  Quantity=@P1, Unit=@P2 ,Company=@P3, Description=@P4, Amount=@P5 Where No=@P6",con);
            
            dt.Parameters.Add("@P1", SqlDbType.VarChar);
            dt.Parameters["@P1"].Value = txtQuantity2.Text ;
            dt.Parameters.Add("@P2", SqlDbType.VarChar);
            dt.Parameters["@P2"].Value = txtUnit2.Text;
            dt.Parameters.Add("@P3", SqlDbType.VarChar);
            dt.Parameters["@P3"].Value = txtCompany2.Text;
            dt.Parameters.Add("@P4", SqlDbType.VarChar);
            dt.Parameters["@P4"].Value = txtDesc2.Text ;
            dt.Parameters.Add("@P5", SqlDbType.VarChar);
            dt.Parameters["@P5"].Value = txtAmt2.Text ;
            dt.Parameters.Add("@P6", SqlDbType.VarChar);
            dt.Parameters["@P6"].Value = textBox1.Text;
                    dt.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * From AccRec ", con);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds;
                    con.Close(
    
    );
