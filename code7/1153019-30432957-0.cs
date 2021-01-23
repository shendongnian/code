     Random ran = new Random();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("ResPending", typeof(Int32));
            for (int i = 0; i < 11; i++)
            {
                DataRow dr = dt.NewRow();
                if (i % 2 == 0)
                {
                    dr[0] = "G123" + i;
                }
                else
                {
                    dr[0] = i;
                }
    
                dr[1] = "an";
                dr[2] = ran.Next(1, 100);
                dt.Rows.Add(dr);
            }
    
            int result = 0;
            //// result =  Convert.ToInt32(dt.Compute("sum(ResPending)", "ID LIKE 'G*'"));
            ////result   = Convert.ToInt32(dt.Compute("Sum(ResPending)", "Substring(ID,0,1)='G'")); ////this throws error.
            var k  = dt.AsEnumerable().Where(x => x.Field<string>("ID").ToString().StartsWith("G"));
