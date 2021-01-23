    private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row in dgv.Rows)
        {
            object obj = row.DataBoundItem;
            if (obj != null)
            {
                IEnumerable listProperties = obj.GetType().GetProperties().Where(p => p.GetValue(obj) is IList);
                foreach (PropertyInfo list in listProperties)
                {
                    IList source = (IList)list.GetValue(obj, null);
                    DataGridViewComboBoxCell cell = (row.Cells[list.Name] as DataGridViewComboBoxCell);
                    cell.DataSource = source;
                    cell.ValueType = source.GetType().GetProperty("Item").PropertyType;
    
                    ValueMember valueMember = (ValueMember)obj.GetType().GetProperty(list.Name).GetCustomAttribute(typeof(ValueMember));
                    DisplayMember displayMember = (DisplayMember)obj.GetType().GetProperty(list.Name).GetCustomAttribute(typeof(DisplayMember));
                    if(valueMember != null && displayMember != null)
                    {
                        cell.ValueMember = valueMember.Value;
                        cell.DisplayMember = displayMember.Value;
                    }
    
                    cell.Value = source[0].GetType().GetProperty("id").GetValue(source[0]);
                }
            }
        }
    }
