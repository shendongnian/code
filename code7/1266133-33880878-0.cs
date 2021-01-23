	int pad1, pad2, height = 28;
	
	FlowLayoutPanel panel = new FlowLayoutPanel();
    panel.AutoScroll = true;
    panel.FlowDirection = FlowDirection.TopDown;
    panel.WrapContents = false;
    for( int x = 0; x < 10; ++x )
    {
	    TableLayoutPanel table = new TableLayoutPanel();
		table.Width = panel.Width;
		// controls
		CheckBox control1 = new CheckBox();
		ComboBox control2 = new ComboBox();
		ComboBox control3 = new ComboBox();
		TextBox  control4 = new TextBox();
		TextBox  control5 = new TextBox();
		CheckBox control6 = new CheckBox();
		// columns and rows number
		table.ColumnCount = 6;
		table.RowCount    = 1;
		// row height
		table.RowStyles.Add( new RowStyle(SizeType.Absolute, height) );
		// widths of columns
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 5.0f ) );
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 24.0f) );
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 20.0f) );
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 22.0f) );
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 24.0f) );
		table.ColumnStyles.Add( new ColumnStyle(SizeType.Percent, 5.0f ) );
		// fill
		control1.Dock = control2.Dock = control3.Dock = control4.Dock =
		control5.Dock = control6.Dock = DockStyle.Fill;
		// margin
		pad1 = (height - control2.Height) / 2;
		pad2 = height - control2.Height - pad1;
		control2.Margin = control3.Margin = new Padding( 2, pad1, 2, pad2 );
		
		// textboxes margin
		pad1 = (height - control4.Height) / 2;
		pad2 = height - control4.Height - pad1;
		control4.Margin = control5.Margin = new Padding( 2, pad1, 2, pad2 );
		// add elements to TableLayoutPanel
		table.Controls.Add( control1, 0, 0 );
		table.Controls.Add( control2, 1, 0 );
		table.Controls.Add( control3, 2, 0 );
		table.Controls.Add( control4, 3, 0 );
		table.Controls.Add( control5, 4, 0 );
		table.Controls.Add( control6, 5, 0 );
		// add table to FlowLayoutPanel
		panel.Controls.Add( table );
    }
