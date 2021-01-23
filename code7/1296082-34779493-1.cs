        protected void Page_Load(object sender, EventArgs e)
        {
              if(!Page.IsPostBack) 
                {
                   dllcust.DataSource = this.Sqls_Cust;
                   dllcust.Databind();
                }
        }
        protected void ddlcust_SelectedIndexChanged(object sender, EventArgs e)
        {
                   dllinvoiceId.DataSource = this.Sqlds_Invoive;
                   dllinvoiceId.Databind();
        }
