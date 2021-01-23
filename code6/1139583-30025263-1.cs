    foreach (Control contrl in this.Controls)
    {
    	if (contrl.Name != "")
    	{
    	     if(contrl is TextBox)
    			vv.Add(((TextBox)contrl).Text);		
    		 else if(contrl is DateTimePicker)
    			vv.Add(((DateTimePicker)contrl).Value);
    		 else if(contrl is NumericUpDown)
    			vv.Add(((NumericUpDown)contrl).Value);
    	}
    
    } 
