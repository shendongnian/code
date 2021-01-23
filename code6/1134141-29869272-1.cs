	public void UpdateUI(object obj, string newValue)
	{
		var property = obj.GetType().GetProperty("writeMessageParams1");
		var writeMessageParams1 = property.GetValue(obj);
	
		var uiFld = wp.GetType().GetField("UIItemEditText");
	
		uiFld.SetValue(writeMessageParams1, newValue);
	
	}
