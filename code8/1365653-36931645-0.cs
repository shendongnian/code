        TableRow row;
        TableCell cell;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.ReloadDynamicControls();
            }
            else
            {
                DynamicControls = new List<Button>();
            }
        }
        private void ReloadDynamicControls()
        {
            if (this.DynamicControls != null)
            {
                foreach (Button button in DynamicControls)
                {
                    button.Click += new EventHandler(btnKill_Click);
                    row = new TableRow();
                    cell = new TableCell();
                    cell.Controls.Add(button);
                    row.Controls.Add(cell);
                    Panel1.Controls.Add(row);
                }
            }
        }
        private List<Button> DynamicControls
        {
            get { return Session["DynamicControls"] != null ? (List<Button>)Session["DynamicControls"] : null; }
            set { Session["DynamicControls"] = value; }
        }
