    void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       // get the selection
       string priv = cmbCategory.SelectedText;
       // get the DataRow
       DataRow[] rows = dt.Select(string.Format("privilege = {0}", priv));
       if (rows.Length > 0)
       {
         DataRow dr = rows[0];
         // and display the info
         txtUser.Text = dr["username"].ToString();
         txtPassword.Text = dr["password"].ToString();
       }
    }
