    protected void addInquiry_Click(object sender, EventArgs e)
    {
         DataTable dt=(DataTable)Session["Inquiry"];
      try
      {
             Quantity = QuantityTxt.Text;
             string Details = Request.Form[Products.UniqueID];
             SelectedProduct = Details.Split('!');
             ProductNo = SelectedProduct[0];
             ProductDescription = SelectedProduct[1];
             ProductSapPack = SelectedProduct[2];
             ProductID = SelectedProduct[3];
             if(dt==null)
             {
                 dt= new DataTable();                       
             }             
             dt.Columns.AddRange(new DataColumn[5] { 
                                 new DataColumn("ProductID",typeof(int)),
                                 new DataColumn("ProductNo", typeof(string)),
                                 new DataColumn("Description", typeof(string)),
                                 new DataColumn("SapPack",typeof(string)),
                                 new DataColumn("Quantity",typeof(string)),
                                 });
            DataRow dr = dt.NewRow();
            dr[0] = ProductID;
            dr[1] = ProductNo;
            dr[2] = ProductDescription;
            dr[3] = ProductSapPack;
            dr[4] = Quantity;
            dt.Rows.Add(dr);
            Inquiries.DataSource = dt;
            Inquiries.DataBind();
            Session.Add("Inquiry",dt);
      }
      finally
      {
            QuantityTxt.Text = String.Empty;
            Description.Text = String.Empty;
            SapPack.Text = String.Empty;
            Products.Text = String.Empty;
      }
    }
