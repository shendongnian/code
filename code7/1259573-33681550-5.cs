     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<MyCustomDate> dates = new List<MyCustomDate>();
                dates.Add(new MyCustomDate() { Date = DateTime.Now.AddYears(1), IsChecked = true, Description = "First Date" });
                dates.Add(new MyCustomDate() { Date = DateTime.Now.AddYears(2), IsChecked = false, Description = "Second Date" });
                dates.Add(new MyCustomDate() { Date = DateTime.Now.AddYears(3), IsChecked = true, Description = "Third Date" });
                this.rptTest.DataSource = dates;
                this.rptTest.DataBind();
            }
        }
