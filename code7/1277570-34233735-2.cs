	// Gets and sets the capacity of this list.  The capacity is the size of
	// the internal array used to hold items.  When set, the internal 
	// array of the list is reallocated to the given capacity.
	// 
	public int Capacity {
		get {
			Contract.Ensures(Contract.Result<int>() >= 0);
			return _items.Length;
		}
		set {
			if (value < _size) {
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
			}
			Contract.EndContractBlock();
 
			if (value != _items.Length) {
				if (value > 0) {
					T[] newItems = new T[value];
					if (_size > 0) {
						Array.Copy(_items, 0, newItems, 0, _size);
					}
					_items = newItems;
				}
				else {
					_items = _emptyArray;
				}
			}
		}
	}
