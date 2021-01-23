     this.id = string.Empty;
     using (MySqlConnection mysqlConn = new MySqlConnection(this.connString))
     {
       string mysqlQuery = @"SELECT * from Student";
       using (MySqlDataAdapter ad = new MySqlDataAdapter(mysqlQuery, this.connString))
         {
           DataSet ds = new DataSet();
           ad.Fill(ds);
           dgvStudentDelete.DataSource = ds.Tables[0];
         }
     }
