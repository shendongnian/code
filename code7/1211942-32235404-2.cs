    private void Refresh()
    {
        PropertyInfo[] properties = GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        if (property.GetCustomAttributes(typeof(RefreshPropertyAttribute), false).Length > 0)
                        {
                            OnPropertyChanged(property.Name)
                        }
                    }
    }
