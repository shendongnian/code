    public int gettotalatlectures(string sub, string rollno)
        {
    
            SqlCommand cmd = new SqlCommand("Select count(*) from attendance where a_user_id='rollno' AND a_subject_code='sub'", sc);
            int x = Convert.ToInt32(cmd.ExecuteScalar());
            return x;
    
        }
    public int getattendance(string sub, string rollno)
    {
        SqlCommand cmd=new SqlCommand("Select active from attendance where a_user_id='rollno' AND a_subject_code='sub'",sc);
        sc.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        int present=0;
        while (rdr.Read())
        {
            string x = rdr["active"].ToString();
            if (x == "True")
            {
                present++;
            }
    
        }
        sc.Close();
        return present;
    
    }
