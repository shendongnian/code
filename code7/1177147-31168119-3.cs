    private void UpButton_Click(object sender, EventArgs e)
    {
        try
        {
            using(con = new SqlConnection(Properties.Settings.Default.SchoolConnectionString))
            {
                con.Open();
                string sqlCommand = "Update (Table) set value=@Value where id=@ID";
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@Value", updatedValue);
                cmd.Parameters.AddWithValue("@ID", idOfRowToUpdate);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 1)
                {
                    MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
