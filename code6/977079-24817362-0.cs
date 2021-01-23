    <asp:DropDownList ID="DropDownList1" runat="server" 
                             DataSource = '<%# Status %>'
                             DataTextField  = "status">
                             </asp:DropDownList>
    protected DataTable Status
        {
            get
            {
                 DataTable dt  = new DataTable();
                
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    string fetch_qry = @"select status from table";
                                 
                    con.Open();
                    using (SqlDataAdapter adpt = new SqlDataAdapter(fetch_qry, con))
                    {
                        
                        adpt.Fill(dt);                    
                    
                    }
                }
               
                    return dt;
            }
        }
