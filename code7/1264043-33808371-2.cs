    private void NudNullBindingSetup(NumericUpDown nud, MyObject obj, string propertyName)
    {
        var b = new Binding("Value", obj, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        b.NullValue = 0;
        b.DataSourceNullValue = null;
        b.Format += (s, e) =>
        {
            var binding = (Binding)s;
            var control = (NumericUpDown)binding.Control;
            control.Value =
                e.Value == binding.DataSourceNullValue ?
                    (int)binding.NullValue : ((int?)e.Value).Value;
        };
        nud.DataBindings.Add(b);
    }
