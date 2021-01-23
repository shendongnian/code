    private void NudNullBindingSetup(NumericUpDown nud, MyObject obj, string propertyName)
    {
        var b = new Binding("Value", obj, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        b.Format += b_Format;
        nud.DataBindings.Add(b);
    }
    void b_Format(object sender, ConvertEventArgs e)
    {
        var value = e.Value as int?;
        ((NumericUpDown)((Binding)sender).Control).Value = value == null ? 0 : value.Value;
    }
