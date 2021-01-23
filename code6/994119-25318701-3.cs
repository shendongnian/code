            BindingSource source = new BindingSource();
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                
                source.Add(new Room() { Type = RoomType.DoubleBB, Price = 50 });
                source.Add(new Room() { Type = RoomType.DoubleFullboard, Price = 60 });
                source.Add(new Room() { Type = RoomType.SingleBB, Price = 40 });
                source.Add(new Room() { Type = RoomType.SingleFullboard, Price = 50 });
                source.Add(new Room() { Type = RoomType.TwinBB, Price = 55 });
                source.Add(new Room() { Type = RoomType.TwinFullboard, Price = 65 });
    
                comboBox1.DataSource = source;
                comboBox1.DisplayMember = "Type";
                comboBox1.ValueMember = "Price";
    
                Binding b = new Binding("Text", source, "Price");
                b.Format += new ConvertEventHandler(b_Format);
    
                textBox1.DataBindings.Add(b);
            }
    
            void b_Format(object sender, ConvertEventArgs e)
            {
               e.Value = string.Format("{0:0 USD}", e.Value);
            }
    
            //private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
            //{
            //    textBox1.Text = comboBox1.SelectedValue.ToString() + "USD";
            //}
