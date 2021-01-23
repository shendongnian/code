        Panel pnl = new Panel();
        ListBox lst = new ListBox();
        ListBox lst2 = new ListBox();
        protected override void OnInit(EventArgs e)
        {
            lst.Attributes["class"] = "cat-list";
            lst.AutoPostBack = true;
            lst.SelectedIndexChanged += Lst_SelectedIndexChanged;
            lst2.AutoPostBack = true;
            lst2.SelectedIndexChanged += Lst_SelectedIndexChanged;
            pnl.Attributes["class"] = "col-sm-2 col-xs-12";
            pnl.Controls.Add(lst);
            categories.Controls.Add(pnl);
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lst.DataSource = cat.list(Convert.ToInt32(0));
                lst.DataTextField = "catName";
                lst.DataValueField = "catId";
                lst.DataBind();
            }
        }
        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            lst2.Attributes["class"] = "cat-list";
            lst2.DataSource = cat.list(Convert.ToInt32(listBox.SelectedValue));
            lst2.DataTextField = "catName";
            lst2.DataValueField = "catId";
            lst2.DataBind();
            pnl.Controls.Add(lst);
            categories.Controls.Add(pnl);
        }
