            List<TextBox> textboxes = new List<TextBox>();
            public Form1()
            {
                InitializeComponent();
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.WrapContents = false;
                flowLayoutPanel1.AutoScroll = true;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                
             
               TextBox tb = new TextBox();
                tb.Left = 3;          
                tb.Font = new Font("Verdana", 12, FontStyle.Bold);
                tb.Size = new Size(325, 25);
                tb.Text = tb.Top.ToString();            
                tb.BorderStyle = BorderStyle.None;           
                flowLayoutPanel1.Controls.Add(tb);
                textboxes.Add(tb);
                
            }
