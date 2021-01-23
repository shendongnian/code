    if(!CheckValidEntities(_value as IEnumerable<Entity>))
	{
		e.Cancel = true;
	
    	foreach (object listItem in _objects)
		{
			_listBox.Items.Add(listItem);
		}						
	}
