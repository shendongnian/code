    //Create "ComboBoxItem" instead of "array"
    while (line != null)
    {
    	//initialize
    	ComboBoxItem cmItem = new ComboBoxItem();
    
    	//set Phone as Display Text
    	cmItem.Content = line;	//it is the Display Text
    	
    	//get Name
    	line = custSR.ReadLine();
    	
    	//set Tag property
    	cmItem.Tag = line;	//it is the attached data to the object
    
    	//add to "Items"
    	phoneComboBox.Items.Add(ComboBoxItem);
    }
