    con.Open();
    cmd = new SqlCommand("SELECT Emp_FName,Emp_LName,T_Subject from Employee where Emp_Position = 'Teacher'", con);
    rdr = cmd.ExecuteReader();
    
    txtTeacher.Items.Clear;
        while (rdr.Read())
        {
            string sub = rdr["T_Subject"].ToString();
            string fname = rdr["Emp_FName"].ToString();
            string lname = rdr["Emp_LName"].ToString();
            string fulname = fname + ' ' + lname;
    
        if (ComboSubDep.Text == sub)
        {
            txtTeacher.Items.Add(fulname);
        }
    }
