		public event EventHandler SelectedCBIndexChanged;
		...
		
		public CustomControl()
		{
			InitializeComponent();
			this.uiComboBox.SelectedIndexChanged += new System.EventHandler(this.uiComboox_SelectedIndexChanged);
		}
		
		
		protected void uiComboox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedCBIndexChanged != null)
				SelectedCBIndexChanged(sender, e);
		}
