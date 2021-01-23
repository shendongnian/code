    List<stu> fillObject(SqlDataReader rd)
    {
        List<stu> stList = new List<stu>();
        //stu stObj = new stu();
        while (rd.Read())
        {
           stList.Add(new stu 
           {
            username = rd["username"].ToString(),
            password = rd["password"].ToString(),
            fname = rd["fname"].ToString(),
            lname = rd["lname"].ToString(),
            faculty = rd["faculty"].ToString()
            
          });
        }
        return stList;
    }
