	private void Label_Click(object sender, EventArgs e)
    {
        Label clickedLabel = sender as Label;
        if (clickedLabel != null)
        {
			var imageIndex = (int)clickedLabel.Tag;
			clickedLabel.Image = _files[imageIndex];
        }
    }
