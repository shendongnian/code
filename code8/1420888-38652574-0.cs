    string _connStr =ConfigurationManager.ConnectionStrings[""].ConnectionString;
            string query = "";
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    query = "SELECT Card_ID,Card_Name From Card_Details"; // Do Change your query according to your requirment
                    DataTable drpdt = SelectedBindValue(query);
                    if (drpdt.Rows.Count > 0)
                    {
                        drp.DataSource = drpdt;
                        drp.DataTextField = "Card_Name";
                        drp.DataValueField = "Card_ID";
                        drp.DataBind();
                    }
                }
            }
    
            protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
            {
                string cardId = drp.SelectedValue;
                query = String.Format("SELECT Card_Type, Card_Type2, Card_Number, Card_Number2, Name_On_Card, Name_On_Card2, Expired_Date, Expired_Date2 From Card_Details where Card_Id = {0}",cardId);
                DataTable lablebind = SelectedBindValue(query);
                if (lablebind.Rows.Count>0)
                {
                    Lbl_CardName.Text = lablebind.Rows[0]["Name_On_Card"].ToString(); // considering there is only one row
                    Lbl_CardType.Text = lablebind.Rows[0]["Card_Type"].ToString();// considering there is only one row
                    Lbl_EDate.Text = lablebind.Rows[0]["Expired_Date"].ToString();// considering there is only one row
                }
            }
            protected DataTable SelectedBindValue(string query) 
            { 
                using(SqlConnection myConnect2 = new SqlConnection(_connStr))
                {               
                    using(SqlDataAdapter sqd = new SqlDataAdapter(query,myConnect2))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sqd.Fill(dt);
                            return dt;
                        }
                    }
                }
            } 
