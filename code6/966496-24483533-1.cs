    protected void btnProcess_Click(object sender, EventArgs e)
    {        
        DataTable dt = new DataTable();
        dt.Columns.Add("companymame");
        dt.Columns.Add("fieldname");
        dt.Columns.Add("fielddetails");
        
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    con.Open();       
                    string data = "select cd.companyname as CompanyName,fd.fieldname, fd.fielddetails from finalcomparedata  fd inner join comparedata cd on fd.compare_id = cd.id where compare_id = @id";
                    SqlCommand cmd = new SqlCommand(data, con); 
                    cmd.Parameters.AddWithValue("@id", id.ToString());                    
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                         while (reader.Read())
                         {
                             DataRow dr = dt.NewRow();
                             dr["companyname"] = reader[0].ToString();
                             dr["fieldname"] = reader[1].ToString();
                             dr["fielddetails"] = reader[2].ToString();
               
                             dt.Rows.Add(dr);               
                          }           
                     }
                } 
                con.Close();
            }
        }
        Repeater3.DataSource = dt;
        Repeater3.DataBind();
    }
   
   
 
