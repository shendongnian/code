    SqlConnection Connection = new SqlConnection("data source=.;initial 
    catalog=testdb;integrated security=sspi;persist security info=true");
    SqlCommand Command = new SqlCommand("select count(studentid) AS StudentsNumber from student", Connection);
    
    Connection.Open();
    object result = Command.ExecuteScalar(); 
    MessageBox.Show(result.ToString());
