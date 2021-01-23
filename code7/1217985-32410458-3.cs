    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            System.Data.DataTable dtobj = new System.Data.DataTable();
            dtobj.Columns.Add("Test");
            dtobj.Rows.Add();
            dtobj.Rows[dtobj.Rows.Count - 1]["Test"] = "Testimg";
            dtobj.Rows.Add();
            dtobj.Rows[dtobj.Rows.Count - 1]["Test"] = "Testimg111";
            dtgDSSP.DataSource = dtobj;
            dtgDSSP.DataBind();
          }
        }
        protected void dtgDSSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropAdd = dtgDSSP.Controls[dtgDSSP.Controls.Count - 1].Controls[dtgDSSP.Controls[0].Controls.Count - 1].Controls[0].FindControl("dropSPAdd") as DropDownList;
            if (dropAdd != null)
            {
                dropAdd.DataSource = Constant.dictSanPham;
                dropAdd.DataValueField = "key";
                dropAdd.DataTextField = "value";
                dropAdd.DataBind();
            }
            
        }
        protected void dtgDSSP_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType  == ListItemType.Footer)
            {
                var dropAdd = e.Item.Controls[0].FindControl("dropSPAdd") as DropDownList;
                if (dropAdd != null)
                {
                    dropAdd.DataSource = Constant.dictSanPham;
                    dropAdd.DataValueField = "key";
                    dropAdd.DataTextField = "value";
                    dropAdd.DataBind();
                }
            }
        }
