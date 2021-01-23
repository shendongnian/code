    private DataGridTextColumn AddColumn(int i, string propName)
    {
        DataGridTextColumn tc = new DataGridTextColumn();
        tc.Header = propName;
        Binding tcBinding = new Binding(string.Format("Fruits[{0}].FruitCount", i));
        tc.Binding = tcBinding;
        return tc;
    }
