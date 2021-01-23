    private static DataGridViewColumn DefaultColumnFactory(Type type)
    {
    	if (type == typeof(bool)) return new DataGridViewCheckBoxColumn(false);
    	if (type == typeof(CheckState)) return new DataGridViewCheckBoxColumn(true);
    	if (typeof(Image).IsAssignableFrom(type)) return new DataGridViewImageColumn();
    	var imageConverter = TypeDescriptor.GetConverter(typeof(Image));
    	if (imageConverter.CanConvertFrom(type)) return new DataGridViewImageColumn();
    	if (!typeof(System.Collections.IList).IsAssignableFrom(type)) return new DataGridViewTextBoxColumn();
    	return null;
    }
