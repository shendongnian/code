    public static void BindEnumToCombobox<T>(this ComboBox comboBox, T defaultSelection)
    {
    	var list = Enum.GetValues(typeof(T))
    		.Cast<T>()
    		.Select(value => new
    		{
    			Description = (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description ?? value.ToString(),
    			Value = value
    		})
    		.OrderBy(item => item.Value.ToString())
    		.ToList();
    
    	comboBox.DataSource = list;
    	comboBox.DisplayMember = "Description";
    	comboBox.ValueMember = "Value";
    
    	foreach (var opts in list)
    	{
    		if (opts.Value.ToString() == defaultSelection.ToString())
    		{
    			comboBox.SelectedItem = opts;
    		}
    	}
    }
