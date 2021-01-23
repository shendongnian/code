         protected void Page_Load(object sender, EventArgs e)
         {
            string queryString = Request.QueryString["ID"];
            ObjectDataSourceDetailBuku.SelectParameters.Add("ID",queryString);
            ObjectDataSourceDetailBuku.DataBind();                
         }
