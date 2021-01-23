     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        private void BindGrid()
        {
         string[] filePaths = Directory.GetFiles(Server.MapPath("~/download"));
         List<ListItem> files = new List<ListItem>();
         foreach (string filePath in filePaths)
         {
            files.Add(new ListItem(Path.GetFileName(filePath), filePath));
         }
           GridView1.DataSource = files;
           GridView1.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
