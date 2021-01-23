        Panel pnl = new Panel();
        ListBox lst1 = new ListBox();
        ListBox lst2 = new ListBox();
        ListBox lst3 = new ListBox();
        protected override void OnInit(EventArgs e)
        {
            lst1.Attributes["class"] = "cat-list";
            lst1.AutoPostBack = true;
            lst1.SelectedIndexChanged += Lst_SelectedIndexChanged;
            lst2.Attributes["class"] = "cat-list";
            lst2.AutoPostBack = true;
            lst2.SelectedIndexChanged += Lst_SelectedIndexChanged;
            lst2.Visible = false;
            lst3.Attributes["class"] = "cat-list";
            lst3.AutoPostBack = true;
            lst3.SelectedIndexChanged += Lst3_SelectedIndexChanged;
            lst3.Visible = false;
            pnl.Attributes["class"] = "col-sm-2 col-xs-12";
            pnl.Controls.Add(lst1);
            pnl.Controls.Add(lst2);
            pnl.Controls.Add(lst3);
            categories.Controls.Add(pnl);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lst1.DataSource = cat.list(Convert.ToInt32(0));
                lst1.DataTextField = "catName";
                lst1.DataValueField = "catId";
                lst1.DataBind();
            }
        }
        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListBox lst;
            if (listBox == lst1)
                lst = lst2;
            else
                lst = lst3;
            lst.DataSource = cat.list(Convert.ToInt32(listBox.SelectedValue));
            lst.DataTextField = "catName";
            lst.DataValueField = "catId";
            lst.DataBind();
            lst.Visible = true;
        }
        private void Lst3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //your code for third Listbox
        }
