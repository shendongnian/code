		public void DisplayRadioButtons()
		{
			Form f = new Form();
			RecursivelyFindRadioButtons(f);
		}
		private static void RecursivelyFindRadioButtons(Control control)
		{
			foreach (Control childControl in control.Controls)
			{
				RecursivelyFindRadioButtons(childControl);
				if (childControl is RadioButton && ((RadioButton) childControl).Checked)
				{
					MessageBox.Show(childControl.Name);
				}
			} 
		}
