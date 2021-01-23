      public void LoadEmployee()
        {
            Employee e = con.GetEmployees();
            tbId.Text = e[id].id.ToString();
            tbFname.Text = e[id].Fname;
            tbLname.Text = e[id].Lname;
            tbDate.Text = e[id].Date;
        }
