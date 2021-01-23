    using(OleDbCommand command1 = conn1.CreateCommand())
    {
        conn.Open();
        command.CommandText = "INSERT INTO Jobsites (JobsiteName, CustomerID) SELECT @jName1, c.CustomerID FROM Customers c WHERE c.CustomerName = @cname1 AND c.BranchNumber = @bNumber1";
        command.Parameters.Add(new OleDbParameter("@jName1", txtJobsiteName.Text));
        command.Parameters.Add(new OleDbParameter("@cName1", cboCustomerName.Text));
        command.Parameters.Add(new OleDbParameter("@bNumber1", cboBranch.Text));
                                       
        command.ExecuteNonQuery();
        conn.Close();
        command.Parameters.Clear();
    }
