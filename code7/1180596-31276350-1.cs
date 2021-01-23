	public void ConvertGuiPBtoGuiPbArray(ref PictureBox[] pictureBoxArray)
	{
		for (int i = 0; i <= pictureBoxArray.Count() - 1; i++)
		{
			int count = i;
			pictureBoxArray[i] = (PictureBox)this.Controls.Cast<Control>().Where(c => c.Name.ToLower() == "picturebox" + (count + 1)).First();
		}
	}
