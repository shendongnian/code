    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridviewData();
            }
        }
        protected void BindGridviewData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            DataRow dtrow = dt.NewRow();    // Create New Row
            dtrow["UserId"] = 1;            //Bind Data to Columns
            dtrow["UserName"] = "SureshDasari";
            dtrow["Education"] = "B.Tech";
            dtrow["Location"] = "Chennai";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();               // Create New Row
            dtrow["UserId"] = 2;               //Bind Data to Columns
            dtrow["UserName"] = "MadhavSai";
            dtrow["Education"] = "MBA";
            dtrow["Location"] = "Nagpur";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();              // Create New Row
            dtrow["UserId"] = 3;              //Bind Data to Columns
            dtrow["UserName"] = "MaheshDasari";
            dtrow["Education"] = "B.Tech";
            dtrow["Location"] = "Nuzividu";
            dt.Rows.Add(dtrow);
            gvDetails.DataSource = dt;
            gvDetails.DataBind();
        }
