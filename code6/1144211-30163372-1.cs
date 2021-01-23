    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var textbox = (sender as TextBox);
			if ((textbox.Tag as PropertyGroup).PropertyGroupName == "the name you want")
			{
				//do stuff
			}
		}
