    public bool IsTextboxValid(TextBox textBox, Action<double> setValue)
    {
        bool parseSucceeds;
        double d;
        if (parseSucceeds = double.TryParse(textBox.Text, out d))
            setValue(d);
        return parseSucceeds;
    }
