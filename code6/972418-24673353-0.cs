        public SortDirection dir
        {
            get {
                if (ViewState["dirstate"] == null)
                {
                    ViewState["dirstate"] = SortDirection.Ascending;
                }
               return (SortDirection)ViewState["dirstate"];
            }
            set {
                ViewState["dirstate"] = value;
            }
        }
        protected void grdemp_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindGrid();
            string Sortdir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                Sortdir = "DESC";
            }
            else
            {
                dir = SortDirection.Ascending;
                Sortdir = "ASC";
            }
            DataView dv = new DataView(dt);
            dv.Sort = e.SortExpression + " " + Sortdir;
            grdemp.DataSource = dv;
            grdemp.DataBind();
            
        }
