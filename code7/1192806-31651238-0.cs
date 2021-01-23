	public string ValueScope
	{
		get
		{
			var values = (this.Value ?? "").Split('/');
			if (values.Length == 2)
				return values[0];
			else
				return null;
		}
		set
		{
			this.Value = (value ?? "") + "/" + this.ValueId.ToString();
		}
	}
	public int ValueId
	{
		get
		{
			int currentValue;
			var values = (this.Value ?? "").Split('/');
			if (values.Length == 2 && int.TryParse(values[1], out currentValue))
				return currentValue;
			else
				return default(int);
		}
		set
		{
			this.Value = (this.ValueScope ?? "") + "/" + value.ToString();
		}
	}
