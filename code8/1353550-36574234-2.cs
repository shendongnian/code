    btDel.Content = (new System.Windows.Controls.Image()
    {
	    Width = 16,
	    Height = 16,
	    HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
	    VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
	    Source = btDel.IsEnabled ? img_Delete : img_DeleteDisabled,
	    OpacityMask = new ImageBrush(img_Delete)
    });
