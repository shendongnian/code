    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strconn))
     {
            SqlCommand cmdSelect = new SqlCommand("select Image from Products where ProductID = '1'", con); 
            con.Open();
            byte[] barrImg = (byte[])cmdSelect.ExecuteScalar();
            MemoryStream ms = new MemoryStream(barrImg);
            Image IMG = Image.FromStream(strfn);
      }
