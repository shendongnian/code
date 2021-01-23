        public void Populate()
        {
            try
            {
                Transaction tran = new Transaction();
               // DataSet ds = tran.GetAllBankTransactions();
                //AH: set the variable 
                Session["pagingQuery"] = tran.GetAllBankTransactions();
                GridView1.DataSource= (DataSet)Session["pagingQuery"];
                GridView1.DataBind();
                ..........
            }
            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
           {
            GridView1.PageIndex = e.NewPageIndex;
            //AH get the data set used to retrieve the query  default page load or search criteria
            GridView1.DataSource = (DataSet)Session["pagingQuery"];
            GridView1.DataBind();
            
        }
