    public void Form5()
    {
        InitializeComponent();
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int year = 1950; year <= DateTime.Today.Year; year++)
            this.comboBox3.Items.Add(year.ToString());
        for (int i = 1; i <= 12; i++)
            this.comboBox1.Items.Add(info.GetMonthName(i));
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Sanity check...
        if(string.IsNullOrWhiteSpace(comboBox3.Text))
        {
            MessageBox.Show("Select an year before!");
            return;
        }
        // Get the current selected year and use it in DaysInMonth
        int year = Convert.ToInt32(comboBox3.Text);
        int month = comboBox1.SelectedIndex;
        if (month >= 0)
        {
            combobox2.DataSource = null;
            month++;
            int days = DateTime.DaysInMonth(year, month);
            var range = Enumerable.Range(1, days);
            comboBox2.DataSource = range.ToList();
        }
    }
