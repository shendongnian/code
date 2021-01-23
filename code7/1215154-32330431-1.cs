        public List<string> list1 { get; set; }
        public List<string> list2 { get; set; }
        public List<string> list3 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    list1 = new List<string> { "a", "b", "c" };
                    DropDownList1.DataSource = list1;
                    DropDownList1.DataBind();
                }
                catch (Exception) { }
            }
        }
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                list2 = new List<string> { "1a", "1b", "1c" };
                DropDownList2.DataSource = list2; 
                DropDownList2.DataBind();
            }
            catch { }
        }
    
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                list3 = new List<string> { "2a", "2b", "2c" };
                DropDownList3.DataSource = list3;
                DropDownList3.DataBind();
            }
            catch (Exception) { }
        }
