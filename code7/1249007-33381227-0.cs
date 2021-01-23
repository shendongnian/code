     string idcan = textBox3.Text;
     string score = textBox4.Text;
     Datatable dt = new DataTable();
     Connection con = new Connection();
     SqlConnection sqlcon = con.Sambung();
     SqlCommand com ;
    
     sqlcon.Open();
     string cek = "select count (ID_Candidate) as Score from DataVote where ID_Candidate = @idcan";  
     
    using(sqlcon)
    {
       using(com = new SqlCommand(cek, sqlcon))
       {
         sqlcon.Open();
        com.Parameter.Add("@idcan",score );
        SqlDataAdapter da = new SqlDataAdapter(com);
        da.File(dt);
        if(dt.Rows.Count >0)
        {
            textBox4.Text = dt.Rows[0]["Score"].ToString();
        }
      }
    }
 }
