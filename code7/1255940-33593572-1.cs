    private void bkwParseColors_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	progressBar1.Value = e.ProgressPercentage;
    
    	var color = (Color)e.UserState;
    	Color lighterColor;
    	if (color.Name != "Black")
    	{
    		var correctionFactor = 0.25f;
    		var red = (255 - color.R)*correctionFactor + color.R;
    		var green = (255 - color.G)*correctionFactor + color.G;
    		var blue = (255 - color.B)*correctionFactor + color.B;
    		lighterColor = Color.FromArgb(color.A, (int) red, (int) green, (int) blue);
    	}
    	else
    	{
    		lighterColor = color;
    	}
    	var drin = lstColors.FindItemWithText(lighterColor.ToArgb().ToString());
    	if(drin==null)
    	{
    		var li = new ListViewItem(lighterColor.ToArgb().ToString());
    		li.BackColor = lighterColor;
    		lstColors.Items.Add(li);
    	}
    }
