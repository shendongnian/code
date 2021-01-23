		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isAnythingChange)
			{
				DialogResult dialogResult = MessageBox.Show("Do you want to save changes", "Message", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					s = (PDVCollection)bindingSource1.DataSource;
					s = s.Save();
				}
				else if (dialogResult == DialogResult.No)
				{
					this.DialogResult = DialogResult.OK;
				}
			}
		}
