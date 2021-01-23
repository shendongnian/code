    public static void BindEnumToCombobox<T>(this ComboBox comboBox, T defaultSelection)
    {
    	var list = Enum.GetValues(typeof(T))
    		.Cast<T>()
    		.Select(value => new
    		{
    			(Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
    			value
    		})
    		.OrderBy(item => item.value.ToString())
    		.ToList();
    
    	comboBox.DataSource = list;
    	comboBox.DisplayMember = "Description";
    	comboBox.ValueMember = "value";
    
    	foreach (var opts in list)
    	{
    		if (opts.value.ToString() == defaultSelection.ToString())
    		{
    			comboBox.SelectedItem = opts;
    		}
    	}
    }
