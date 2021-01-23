    WrapPanel wp = new WrapPanel();
    for (int i = 0; i < 10; i++)
    {
    	CheckBox chb = new CheckBox();
    	chb.Name = string.Format("Id{0}", i);
    	wp.Children.Add(chb);
    }
    
    foreach (CheckBox el in wp.Children)
    {
    	if (el.Name == "Id3")
    	{
    		return el;
    	}
    }
