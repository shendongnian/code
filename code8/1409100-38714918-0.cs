        void Handle_Clicked(object sender, System.EventArgs e)
		{
			ClearRadioGroup();
		}
		private void ClearRadioGroup()
		{
			foreach (var child in grupa.Children)
			{
				var radio = (CustomRadioButton)child;
				radio.Checked = false;
			}
		}
