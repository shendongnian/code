    public void FillDataTable(string sSQL, DataTable dt)// DataTable operations 
                {
                    this.cmd = new SqlCommand(sSQL, this.conn);
                    this.dataAdapter = new SqlDataAdapter(this.cmd);
                    this.dataAdapter.Fill(dt);
        
                }
