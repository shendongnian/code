    public string ExpoFunc()
    {
        string dateInString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        DateTime startDate = DateTime.Parse(dateInString);
    
       //******Declare outside the loope
        DateTime expiryDate = new DateTime();
        if (ddlplan.SelectedItem.Text.Substring(0, 6) == "Weekly")
       {
            expiryDate = startDate.AddDays(7);
        }
        else if (ddlplan.SelectedItem.Text.Substring(0, 7) == "1 Month")
        {
            expiryDate = startDate.AddMonths(1);
        }
        if (ddlplan.SelectedItem.Text.Substring(0, 9) == "12 Months")
        {
           expiryDate = startDate.AddMonths(12);
        }
        con.Open();
        string strupdate = "Update Users set t_effectiveto='" +     Convert.ToDateTime(expiryDate) + "' where c_planduration='" + ddlplan.SelectedItem.Text + "' and c_mail='" + txtmail.Text + "'";
        //expiryDate confilct with declaration 
        SqlCommand cmd1 = new SqlCommand(strupdate,con);
        cmd1.ExecuteNonQuery();
        con.Close();     
        //this will return the date as well... just in case  
        return strupdate;
    }
