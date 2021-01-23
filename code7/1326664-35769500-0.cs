             protected void Page_Load(object sender, EventArgs e)
             {
             if (!Page.IsPostBack)
             {
              
                DataTable dt1 = new DataTable();
                dt1.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Name") });
                dt1.Rows.Add(1, "Shirt");
                dt1.Rows.Add(2, "Jeans");
                ddlCloth.DataSource = dt1;
                ddlCloth.DataTextField = "Name";
                ddlCloth.DataValueField = "Id";
                ddlCloth.DataBind();
            }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(ddlCloth.SelectedItem.Value);
            string text = Convert.ToString(ddlCloth.SelectedItem.Text);
            int index=Convert.ToInt32(ddlCloth.SelectedIndex);
        }
        
