    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblServerDateTime.Text = DateTime.Now.ToString("dd MMMM");
                // Sets current date on initially.
            }
        }
    protected void btnUp_Click(object sender, EventArgs e)
        {
            //Up button click will increase the date by one day
            DateTime.TryParse(lblServerDateTime.Text, out d);
            d = d.AddDays(1);
            lblServerDateTime.Text = d.ToString("dd MMMM");
            calCurrentDay.SelectedDate = d;
        }
    protected void btnDown_Click(object sender, EventArgs e)
        {
            //Up button click will decrease the date by one day
            DateTime d;
            DateTime.TryParse(lblServerDateTime.Text, out d);
            d = d.AddDays(-1);
            lblServerDateTime.Text = d.ToString("dd MMMM");
            calCurrentDay.SelectedDate = d;
        }
