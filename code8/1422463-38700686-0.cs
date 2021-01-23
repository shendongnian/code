        ListBox lst = new ListBox();
        protected override void OnInit(EventArgs e)
        {
            lst.AutoPostBack = true;
            lst.SelectedIndexChanged += Lst_SelectedIndexChanged;
            form1.Controls.Add(lst);
        }
        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I use this for clear old items
            lst.Items.Clear();
            //add new items
            lst.Items.Add(new ListItem("third"));
            lst.Items.Add(new ListItem("forth"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //add items manual or with data scource 
                lst.Items.Add(new ListItem("first"));
                lst.Items.Add(new ListItem("second"));
            }
        }
