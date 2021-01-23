        DataTable dt = new DataTable();
        object[,] piclist = new object[aantal, 2]; // Note: different column number
        try
        {
            conn.Open();
            // Create a new DataTable
            da.Fill(dt);
            foreach (DataRow drRow in dt.Rows)
            {
                // Note: accessing each column separately.
                piclist[loop, 0] = (drRow["PictureLocation"].ToString());
                piclist[loop, 1] = (drRow["MenuId"].ToString());
                loop++;
            }
        }
 
