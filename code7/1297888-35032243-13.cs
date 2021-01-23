	public void Add(Person item)
	{
		if(item == null)
		{
			throw new ArgumentNullException("Cannot add null to PersonList");
		}
	
		if(_size == _items.Length)
		{
			EnsureCapacity(_size + 1);
		}
		
		_items[_size++] = item;
	}
