    public static class DataGridViewExtensions
    {
    	public static void Bind(this DataGridView view, object dataSource, string dataMember = "", Func<PropertyDescriptor, DataGridViewColumn> columnFactory = null)
    	{
    		var columns = new List<DataGridViewColumn>();
    		var properties = ListBindingHelper.GetListItemProperties(dataSource, dataMember, null);
    		for (int i = 0; i < properties.Count; i++)
    		{
    			var property = properties[i];
    			if (!property.IsBrowsable) continue;
    			var column = (columnFactory != null ? columnFactory(property) : null) ?? DefaultColumnFactory(property.PropertyType);
    			if (column == null) continue;
    			column.DataPropertyName = property.Name;
    			column.Name = property.Name;
    			column.HeaderText = !string.IsNullOrEmpty(property.DisplayName) ? property.DisplayName : property.Name;
    			column.ValueType = property.PropertyType;
    			column.ReadOnly = property.IsReadOnly;
    			columns.Add(column);
    		}
    		view.DataSource = null;
    		view.Columns.Clear();
    		view.AutoGenerateColumns = false;
    		view.Columns.AddRange(columns.ToArray());
    		view.DataMember = dataMember;
    		view.DataSource = dataSource;
    	}
    
    	private static DataGridViewColumn DefaultColumnFactory(Type type)
    	{
    		if (type == typeof(bool)) return new DataGridViewCheckBoxColumn(false);
    		if (type == typeof(CheckState)) return new DataGridViewCheckBoxColumn(true);
    		if (typeof(Image).IsAssignableFrom(type)) return new DataGridViewImageColumn();
    		var imageConverter = TypeDescriptor.GetConverter(typeof(Image));
    		if (imageConverter.CanConvertFrom(type)) return new DataGridViewImageColumn();
    		// Begin custom default factory
    		if (type == typeof(DateTime)) return new CalendarColumn();
    		// End custom default factory
    		if (!typeof(System.Collections.IList).IsAssignableFrom(type)) return new DataGridViewTextBoxColumn();
    		return null;
    	}
    }
