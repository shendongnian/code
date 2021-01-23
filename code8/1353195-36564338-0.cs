     private void Find_Click(object sender, EventArgs e)
     {
         DataTable table = null;
         using (SqlConnection vcon1 = new SqlConnection(this.connectionString))
         {
             try
             {
                 vcon1.Open();
                 SqlCommand Vcom = vcon1.CreateCommand();
                 Vcom.CommandText = "SELECT * FROM AssignedSolution WHERE CASEID = @caseid";
                 Vcom.Parameters.Add(new SqlParameter("@caseid", txtCASEID.Text));
                 using (SqlDataAdapter adapter = new SqlDataAdapter(Vcom))
                 {
                     table = new DataTable();
                     adapter.Fill(table);
                 }
             }
             catch (Exception ex)
             {
                 //Handle your exception;   
             }
         }
         dataGridView1.DataSource = table;
     }
