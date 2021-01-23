	void Main()
	{
		var lbl1 = new TextBlock{ Text = "Input value ", MinWidth = 70 } ;
		var lbl2 = new TextBlock{ Text = "Results     ", MinWidth = 70  } ;
		
		var tb 	= new TextBox{ 	 MinWidth = 500 } ;
	 
		var btn = new Button { Content = " Calc " };
		btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
		btn.Margin = new System.Windows.Thickness(5,1,1,1);
		btn.MaxWidth = 100;
		
		var results = new TextBlock{ Text = ""  } ;
		btn.Click += (sender, args) => { results.Text = Calc(tb.Text); } ;
		
		var panel1 = new DockPanel();
		panel1.Children.Add(lbl1);
		panel1.Children.Add(tb);
		panel1.Children.Add(btn);
		
		var panel2 = new DockPanel();
		panel2.Children.Add(lbl2);
		panel2.Children.Add(results);
		
		PanelManager.StackWpfElement(panel1, "Example");
		PanelManager.StackWpfElement(panel2, "Example");
	}
