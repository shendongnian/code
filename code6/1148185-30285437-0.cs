    try
    {
    .....
    con.Open();
            SqlCommand cmd = new SqlCommand(@"Select count(*) from GlennTeoStudents
                                               WHERE (IndexNumber='" + numIN.Value + "')", con);
    
    int count1 = cmd.ExecuteScalar();
    
    if (count1 != 0)
      {
    do your update
    }
    else
    {
     give your message box
    }
    
    }
