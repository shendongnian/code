	public ExcelRange this[string Address]
	{
		get
		{
			if (_worksheet.Names.ContainsKey(Address))
			{
				if (_worksheet.Names[Address].IsName)
				{
					return null;
				}
				else
				{
					base.Address = _worksheet.Names[Address].Address;
				}
			}
			else
			{
				base.Address = Address;
			}
			_rtc = null;
			return this;
		}
	}
