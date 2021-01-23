		public Form1()
		{
			InitializeComponent();
			textBox1.TextChanged += TextChanged;
			textBox2.TextChanged += TextChanged;
		}
		private void TextChanged(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;
			string text = tb.Text;
            calculateTotalFructiferous(text);
		}
        public void calculateTotalFructiferous(string text) 
        { 
            totalFructiferous.Text = ....;
        }
	}
