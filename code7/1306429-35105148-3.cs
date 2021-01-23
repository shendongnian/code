	private void OnNext(int index, TSource value)
	{
		lock (_gate)
		{
			_values[index] = value;
			_hasValue[index] = true;
			if (_hasValueAll || (_hasValueAll = _hasValue.All(Stubs<bool>.I)))
			{
                    /* snip */
					res = _parent._resultSelector(new ReadOnlyCollection<TSource>(_values));
                    /* snip */
				_observer.OnNext(res);
			}
			/* snip */
		}
	}
