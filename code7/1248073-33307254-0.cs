		public Form1()
		{
			InitializeComponent();
			this.Load += Form1_Load;
		}
		void Form1_Load(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Control c in this.Controls)
            {
				sb.AppendLine(c.Name);
                if( c is TextBox )
                   ...
                if( c is ComboBox )
                   ...
                etc...
            }
		}
