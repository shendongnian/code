		private void btGroupUp_Click(object sender, RoutedEventArgs e)
		{
			for (var i=1;i<50;i++)
			{
				TextBox box = new TextBox();
				box.Text = "Hello World " + i ;
				lbPPgroups.Items.Add(box);
			}
		}
