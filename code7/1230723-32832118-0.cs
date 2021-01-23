    public void loadGrid<T>(IList<T> datasource)
    {
        generateDataGridViewColumns(datasource);
    
        IBindingList source = new BindingList<T>(datasource);
        inputsDgv.AutoGenerateColumns = false;
        inputsDgv.AllowUserToAddRows = false;
        inputsDgv.AllowUserToDeleteRows = false;
        inputsDgv.DataSource = source;
    }
    private void generateDataGridViewColumns(IList<T> datasource)
    {
        if (datasource != null && datasource.Count > 0 && datasource[0] != null)
        {
            foreach (PropertyInfo property in datasource[0].GetType().GetProperties())
            {
                DataGridViewColumn col;
                var displayNameObj = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().FirstOrDefault();
                string displayName = (displayNameObj == null) ? property.Name : displayNameObj.DisplayName;
    
                if (property.GetValue(datasource[0]) is IList)
                {
                    col = new DataGridViewComboBoxColumn();
                    (col as DataGridViewComboBoxColumn).AutoComplete = false;
                    (col as DataGridViewComboBoxColumn).ValueType = typeof(Object);
                }
                else
                {
                    col = new DataGridViewTextBoxColumn() { DataPropertyName = property.Name };
                }
    
                col.Name = property.Name;
                col.HeaderText = displayName;
                ReadOnlyAttribute attrib = Attribute.GetCustomAttribute(property, typeof(ReadOnlyAttribute)) as ReadOnlyAttribute;
                col.ReadOnly = (!property.CanWrite || (attrib != null && attrib.IsReadOnly));
                inputsDgv.Columns.Add(col);
            }
        }
    }
