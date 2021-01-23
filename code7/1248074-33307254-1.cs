		public Form1()
		{
			InitializeComponent();
			this.VisibleChanged += Form1_VisibleChanged;
		}
		void Form1_VisibleChanged(object sender, EventArgs e)
		{
			if (!this.Visible)
				return;
			// Disable the event hook, we only need it once.
			this.VisibleChanged -= Form1_VisibleChanged;
			StringBuilder sb = new StringBuilder();
			foreach (Control c in this.Controls)
				sb.AppendLine(c.Name);
		}
