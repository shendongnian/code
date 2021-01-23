    private void button1_Click(object sender, EventArgs e)
    {
         string cmdText = @"Insert into TableDate_Time 
                           (DateTime ) OUTPUT INSERTED.myID values (@DateTime)";
         using(SqlConnection cn = new SqlConnection("...."))
         using(SqlCommand cm = new SqlCommand(cmdText, cn))
         {
             cn.Open();
             cm.Parameters.Add("@DateTime", SqlDbType.DateTime);
             cm.Parameters["@DateTime"].Value = DateTime.Now;  
             Guid id = (Guid)cm.ExecuteScalar();
             .... 
         }
    }
