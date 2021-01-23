    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text; // Get the last name
            SqlConnection conn = new SqlConnection(strCon);
            SqlDataAdapter da = new SqlDataAdapter("select * from usertable where usertable.firstname=@fn and usertable.lastname=@ln", conn); // Add last name to query
            da.SelectCommand.Parameters.Add("@fn");
            da.SelectCommand.Parameters["@fn"].Value = fname;
            da.SelectCommand.Parameters.Add("@ln"); // New parameter.
            da.SelectCommand.Parameters["@ln"].Value = lname;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                args.IsValid = true;
        }
