        public Form1()
        {
            InitializeComponent();
            mthCalendarMaster.DateSelected += mthCalendarMaster_DateSelected;
        }
        private void mthCalendarMaster_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = e.Start.ToShortDateString();
            else
                textBox2.Text = e.Start.ToShortDateString();
        }
