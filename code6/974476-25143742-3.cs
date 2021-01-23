		private void Window_Moved(object sender, EventArgs e)
		{
			if (win2 != null)
			{
				win2.Left = Left;
				win2.Top = Top;
			}
		}
