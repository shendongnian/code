     private void tbMemberID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox= sender as Textbox;
                //int RowsAffected = 0;
                DataAccess oDataAccess = new DataAccess();
                con.Open();
                oDataAccess.cmd.CommandText = "SELECT MemberName FROM AccountInfo where MemberID='" + txtBox.Text + "'";
                oDataAccess.cmd.Connection = con;
    
                tbMemberName.Text = ((string)cmd.ExecuteScalar());
                con.Close();
            }
    
            catch (Exception ex)
            {
    
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
