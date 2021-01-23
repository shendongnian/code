    public void bindStudentID()
    {
    //instantiating a ArrayList object does not need to be included inside Try/Catch block
    //try
    //{
        ArrayList a = new ArrayList();
    try
    {
        //Before opening the connection make sure that connection's current state is not open, otherwise you will get exception
        //con.Open();
     if (con.State != ConnectionState.Closed)
     {
         con.Close();
     }
     con.Open();
        SqlCommand cmd = new SqlCommand("SELECT studentId FROM tbStudent",     con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            a.Add(dr["studentId"]);
        }
        comboBox1.DataSource = a;
     //You should close data reader before using it again or defining new one
        dr.Close();
        ArrayList aa = new ArrayList();
     //No need to define new SqlCommand object and you can use the prev one
        cmd = new SqlCommand("SELECT SemesterID FROM tbSemester     Where StudentID='" + comboBox1.Text + "'", con);
     //No need to define new SqlDataREader object and you can use the prev one
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            aa.Add(dr["SemesterID"]);
            comboBox2.DataSource = aa;
        }
         //You should close data reader before using it again or defining new one
        dr.Close();
    //Close the connection in finally block        
    //con.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
     //You should also close the connection even if an exception raised
            con.Close();
    }
    }
