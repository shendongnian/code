	public void Add(Person item)
	{
		if(_size == _items.Length)
		{
			EnsureCapacity(_size + 1);
		}
		
		_items[_size++] = item;
	}
	
