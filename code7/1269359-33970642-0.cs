     [WebMethod]
      public Student[] getall()
     {
        
        Student[] stds = new Student[400];
        SqlConnection conn;
        conn = Class1.ConnectionManager.GetConnection();
        conn.Open();
        SqlCommand newCmd = conn.CreateCommand();
        newCmd.CommandType = CommandType.Text;
        newCmd.CommandText = "select * from dbo.tblUser";
        SqlDataReader sdr = newCmd.ExecuteReader();
        for (int runs = 0; sdr.Read(); runs++)
        {
            Student objStd = new Student();
            objStd.id = Int32.Parse(sdr["Id"].ToString());
            objStd.name = sdr["name"].ToString();
            objStd.grade = sdr["grade"].ToString();
            stds[runs] = objStd;
        }
        conn.Close();
        sdr.Close();
        return stds;
     }
