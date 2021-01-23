        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mthCalendarMaster.DateSelected += mthCalendarMaster_DateSelected;
        }
        private void mthCalendarMaster_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = e.Start.ToString();
            else
                textBox2.Text = e.Start.ToString();
        }
