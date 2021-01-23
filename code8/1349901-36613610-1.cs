                byte[] imgByte = null;
            con = new SqlConnection("MyConnectionString");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Events", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                imgByte = (byte[])(dr["EvtImage"]);
                string str = Convert.ToBase64String(imgByte);
                imageTest.Src = "data:Image/png;base64," + str;
            }
