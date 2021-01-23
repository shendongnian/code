	public string SomeProperty
	{
		get { return _wcfObject.SomeProperty; }
		set { 
				var v = _wcfObject.SomeProperty;
				Set(nameof(SomeProperty), ref v, value);
				_wcfObject.SomeProperty = v;
			}
	}
