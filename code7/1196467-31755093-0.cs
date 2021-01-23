DataGridView.BindingList = new BindingList<object who inherits this>()
    public void SetFieldValue<T>(T field, T value, params string[] propertyNames)
    {
          Foreach var propName In PropertyNames
          {
                NotifyPropertyChanged(propName)
          }
    }
