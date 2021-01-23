    void btnOK_MouseDown(object sender, MouseEventArgs e)
	{
		_objects = new List<object>();
		foreach (object listItem in _listBox.Items)
		{
			_objects.Add(listItem);
		}			
    }		
