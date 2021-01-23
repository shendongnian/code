        txtTeacher.Items.Clear();
        while (rdr.Read())
       {
           string sub = rdr["T_Subject"].ToString();
           string fname = rdr["Emp_FName"].ToString();
           string lname = rdr["Emp_LName"].ToString();
           string fulname = fname + ' ' + lname;
    
        if(sub=="Math")
        {
    
            txtTeacher.Items.Add(fulname);
        }
    }
