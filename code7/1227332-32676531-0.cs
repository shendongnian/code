	public bool TryGetValue(TKey key, out TItem value)
	{
		WeakReference<TItem> weakReference;
	
		if (_itemStorage.TryGetValue(key, out weakReference))
		{
			if (weakReference.TryGetTarget(out value))
			{
				return true;
			}
			else
			{
				value = default(TItem);
			}
		}
	
		return false;
	}
