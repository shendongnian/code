    private void CheckEmail(ref string EmailAddress)
    {
        if ((ds.Tables("Check") != null))
        {
            ds.Tables("Check").Clear();
        }
        string str = "select * from yourtablename where Email='" + EmailAddress + "'";
        SqlDataAdapter Da = new SqlDataAdapter(str, Con);
        Con.Open();
        Da.Fill(ds, "Check");
        if (ds.Tables("Check").Rows.Count > 0)
        {
            lbl.text = "Email Exists";
        }
        else
        {
            lbl.text = "Email Not fount";
        }
        Con.Close();
    }
