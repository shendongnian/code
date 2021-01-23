     public void FillCmbo(String Sql, ComboBox cmb, String name)
       {
           try
           {
               if (Con.State == ConnectionState.Open)
                   Con.Close();
               Con.Open();
 
              SqlConnection con = new SqlConnection(Sql, Con);
               SqlCommand cmd = new SqlCommand("Select Name from mr000 where Type&0x0f=3", con);
               DataTable dt = new DataTable();
               con.Fill(dr);        
               dt.Rows.InsertAt(Drw, 0);
               cmb.Name = "combocust";
               cmb.DisplayMember =name;
               cmb.HeaderText = "Change Customer";
               cmb.DataSource = dt;
           }
           catch (System.Exception ex)
           {
 
               MessageBox.Show(ex.Message, "Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
       }
