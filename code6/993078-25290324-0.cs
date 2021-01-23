            string path = @"yourpathhere";
            List<string> dates = new List<string>();
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                dates.Add(DateTime.Now.ToString());
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                dates.Add(DateTime.Now.ToString());
                File.WriteAllText(path, dates.Aggregate((d1, d2) => d1 + "\r\n" + d2));
            }
