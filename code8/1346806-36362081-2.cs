	public void Add(T item)
	{
		if (!EqualityComparer<T>.Default.Equals(_content[_size - 1], default (T)))
			throw new ArgumentOutOfRangeException("The Array is full");
		if (_size > 0)
		{
			for (int i = 0; i <= _size; i++)
			{
				if (EqualityComparer<T>.Default.Equals(_content[i], default (T)))
				{
					_content[i] = item;
					break;
				}
			}
		}
	}
