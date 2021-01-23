    List<string> checks = new List<string>();
    foreach (Control cont in this.groupBox1.Controls)
        {
            if (cont is CheckBox)
            {
                if (((CheckBox)cont).Checked == true)
                {
                    checks.Add(((CheckBox)cont).Text);
                }
            }
        }
    sqlcon.Open();
    SqlCommand sqlcmd = new SqlCommand("INSERT INTO TBL_EXAMPLE VALUES ( '" + string.Join(" ",checks) + "')", sqlcon);
    sqlcmd.ExecuteNonQuery();
    sqlcon.Close();
    MessageBox.Show("OK");
