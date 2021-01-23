            BindingSource source = new BindingSource();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                SetSource();
                textBox1.DataBindings.Add("Text", source, "Start", true);
                textBox2.DataBindings.Add("Text", source, "End", true);
            }
    
            private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
            {
                SetSource();
            }
    
            private void SetSource()
            {
                source.DataSource = monthCalendar1.GetDisplayRange(true);
            }
        }
