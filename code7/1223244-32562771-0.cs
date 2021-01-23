    private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
    	if (!this.propertyGrid1.RectangleToScreen(this.DisplayRectangle).Contains(Control.MousePosition))
    	{
    		if (this.ActiveControl == this.propertyGrid1) { this.ActiveControl = null; }
    	}
    }
