    protected void Page_Load(object sender, EventArgs e)
    {
        string studentid = Session["student_id"].ToString();
        string i = studentid;
        using(SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
        using(SqlCommand cmd = new SqlCommand("atend", sc))
        {
            sc.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rollno", studentid);
            using(SqlDataReader rdr = cmd.ExecuteReader())
            {
                .... 
               while (rdr.Read())
               {
                  ...
                  dataRow["Total Lectures"] = gettotalatlectures(sc, subject, studentid);
                  dataRow["Attend Lectures"] = getattendance(sc, subject, studentid);
                  table.Rows.Add(dataRow);
               }
          }
        }
        GridView1.DataSource = table;
        GridView1.DataBind();   
    }
    public int getattendance(SqlConnection sc, string sub, string rollno)
    {
        using(SqlCommand cmd=new SqlCommand("Select active from attendance where a_user_id='rollno' AND a_subject_code='sub'",sc))
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
           .....
        }
        return present;
    }
    public int gettotalatlectures(SqlConnection sc, string sub, string rollno)
    {
        using(SqlCommand cmd = new SqlCommand("Select count(*) from attendance where a_user_id='rollno' AND a_subject_code='sub'", sc))
        {
            int x = Convert.ToInt32(cmd.ExecuteScalar());
        
            return x;
        }
    }
