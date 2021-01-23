                ASP.Net Code :
           ---------------
    
    	<asp:DropDownList ID="ddList" runat="server" AutoPostBack="True" Height="65px" OnSelectedIndexChanged="ddList_SelectedIndexChanged" Width="198px">
            </asp:DropDownList>
    
    
    C# Code :
    ---------
    
     public void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    dropdown();
                }
            }
    .
    <your code goes here> ....
    
    public void dropdown()
            {
                //String Sql statement
                string Sqlstr = "select CountryCode,Description from ca_countryMaster order by description";
                
    
                string DBCon = "Data Source=RAJA;Initial Catalog=CareHMS;Integrated Security=True;";
                SqlConnection SqlCon = new SqlConnection(DBCon);
                SqlCon.Open();
    
                SqlDataAdapter Sqlda = new SqlDataAdapter(Sqlstr, SqlCon);
                DataSet ds = new DataSet();
                Sqlda.Fill(ds);
                ddList.DataSource = ds.Tables[0];
                ddList.DataTextField = "Description";
                ddList.DataValueField = "CountryCode";
                ddList.DataBind();
    
                ds.Dispose();
                Sqlda.Dispose();
                SqlCon.Close();
            }
