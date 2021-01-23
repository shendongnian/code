        SqlParameter[] p = new SqlParameter[6];
        p[0] = new SqlParameter("@ExamTypeId", Examtypeid);
        p[1] = new SqlParameter("@ExamName", Examname);
        p[2] = new SqlParameter("@Description", Desc);
        p[3] = new SqlParameter("@NoOfQues", Noofquestions);
        p[4] = new SqlParameter("@NegativeMarking", Negativemarking);
        p[5] = new SqlParameter("@Out", SqlDbType.VarChar, 150);
        p[5].Direction = ParameterDirection.Output;
