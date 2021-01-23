    protected void myRowCommand(object sender, GridViewCommandEventArgs e) 
    {
     String connectionString = "Server=root;Database=test;User=name;Password=test;";
      
     GridViewRow row = this.GridView1.SelectedRow; 
                int EntryID = row.RowIndex;
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
              SqlCommand cmd = new SqlCommand("INSERT INTO Answers (QuestionID, Answer_Name, Answer)" +
                       "VALUES (EntryID, '" + txtName.Text + "', '" + txtAnswer.Text + "')");
              cmd.Connection = conn;
              conn.Open();
              cmd.ExecuteScalar().ToString();
         }
      
      }
    }
