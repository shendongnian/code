		var pairs = new[]
		{
			new { Button = button1, UserControl = userControl1 },
			new { Button = button2, UserControl = userControl2 },
			new { Button = button3, UserControl = userControl3 },
			new { Button = button4, UserControl = userControl4 },
			new { Button = button5, UserControl = userControl5 },
			new { Button = button6, UserControl = userControl6 },
			new { Button = button7, UserControl = userControl7 },
			new { Button = button8, UserControl = userControl8 },
			new { Button = button9, UserControl = userControl9 },
			new { Button = button10, UserControl = userControl10 },
			new { Button = button11, UserControl = userControl11 },
			new { Button = button12, UserControl = userControl12 },
			new { Button = button13, UserControl = userControl13 },
			new { Button = button14, UserControl = userControl14 },
			new { Button = button15, UserControl = userControl15 },
			new { Button = button16, UserControl = userControl16 },
			new { Button = button17, UserControl = userControl17 },
			new { Button = button18, UserControl = userControl18 },
			new { Button = button19, UserControl = userControl19 },
			new { Button = button20, UserControl = userControl20 },
		};
	
		foreach (var pair in pairs)
		{
			pair.UserControl.Visible = false;
			pair.Button.Click += (s, e2) =>
			{
				foreach (var pair2 in pairs) { pair2.UserControl.Visible = false; }
				pair.UserControl.Visible = true;
			};
		}
