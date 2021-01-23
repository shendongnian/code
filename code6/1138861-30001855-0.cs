    StringBuilder name = new StringBuilder();
    foreach (Control cont in this.groupBox1.Controls)
    {
        if (cont is CheckBox)
        {
            if (((CheckBox)cont).Checked == true)
            {
                name.Append(((CheckBox)cont).Text.ToString() + " ");
            }
        }
    }
    
    sqlcon.Open();
    SqlCommand sqlcmd = new SqlCommand("INSERT INTO TBL_EXAMPLE VALUES ( '" + name.ToString().Trim() + "')", sqlcon);
    sqlcmd.ExecuteNonQuery();
    sqlcon.Close();
    MessageBox.Show("OK");
