    public void DeleteReciver(int[] Reciver_numbers)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            for (int i = 0; i < Reciver_numbers.Length; i++)
            {
                param[0] = new SqlParameter("@Reciver_number", SqlDbType.Int);
                param[0].Value = Reciver_number[i];
                DAL.excutecommand("DeleteReciver", param);
            }
            DAL.close();
        }
