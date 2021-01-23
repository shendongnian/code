    public void loadGrid<T>(IList<T> datasource)
    {
        generateDataGridViewColumns<T>(datasource);
    
        IBindingList source = new BindingList<T>(datasource);
        inputsDgv.AutoGenerateColumns = false;
        inputsDgv.AllowUserToAddRows = false;
        inputsDgv.AllowUserToDeleteRows = false;
        inputsDgv.DataSource = source;
    }
    private void generateDataGridViewColumns<T>(IList<T> datasource)
    {
        if (datasource != null)
        {
            dgv.Columns.Clear();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                DataGridViewColumn col;
                var displayNameObj = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().FirstOrDefault();
                string displayName = (displayNameObj == null) ? property.Name : displayNameObj.DisplayName;
    
                if (property.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null && property.PropertyType != typeof(string))
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
