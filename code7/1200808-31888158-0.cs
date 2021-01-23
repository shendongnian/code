    public DataTable Add_new(string t1, string t2, string t3, string t4,
                             string t5, string t6, string t7, string t8,
                             string t9, string t10)
            {
                OleDbParameter[] param = new OleDbParameter[10];
            for (int i = 1; i < 11; i++)
            {
                param[i - 1] = new OleDbParameter("" + i + "", OleDbType.VarChar);
                switch("t" + i)
                {
                    case "t1":
                        param[i - 1].Value = t1;
                        break;
                    case "t2":
                        param[i - 1].Value = t2;
                        break;
                   //Recreate up to t10
                }
            }
            DataTable dt = new DataTable();
            dt = DAL.selectdata("Add_Code", param);
            return dt;
        }
