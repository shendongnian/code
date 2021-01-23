    private string SearchString = "";
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            public string HighlightText(string InputText)
            {
                string Search_str = searchText.Text;
                Regex RegExp = new Regex(Search_str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
                return RegExp.Replace(InputText, new MatchEvaluator(ReplaceKeywords));
            }
            public string ReplaceKeywords(Match m) //this is just to highlight the item searched
            {
                return ("<span class=highlight>" + m.Value + "</span>");
            }
            private DataTable GetData(string query)
            {
                // Read connection string from web.config file , Important, change the 
                //ConnectionStrings name here (testConnectionString)
                // and replace it with your connection name , you can find it in web.config file
                // in <connectionStrings> tag , you find it after this tag <add name="
                string CS = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    using (DataTable dt = new DataTable())
                    {
                        con.Open();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
            string searchSQL;
            protected void ButtonSearch_Click(object sender, EventArgs e)
            {
                SearchString = searchText.Text;
                // here
             
                //bind the SCHOLARSHIPCONTRACT table data into GridView1
                if (DropDownList1.SelectedValue == "Contract Number")
                {
                    searchSQL = "SELECT * FROM [SCHOLARSHIPCONTRACT] WHERE ContractNo =' " + SearchString + "'";
                }
                else if (DropDownList1.SelectedValue == "Training Code")
                {
                    searchSQL = "SELECT * FROM [SCHOLARSHIPCONTRACT] WHERE TrainingCode =' " + SearchString + "'";
                }
                else if (DropDownList1.SelectedValue == "Employee ID")
                {
                    searchSQL = "SELECT * FROM [SCHOLARSHIPCONTRACT] WHERE EmpID =' " + SearchString + "'";
                }
                DataTable dt = this.GetData(searchSQL);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            protected void ButtonClear_Click(object sender, EventArgs e)
            {
                searchText.Text = "";
                SearchString = "";
                GridView1.DataBind();
            }
