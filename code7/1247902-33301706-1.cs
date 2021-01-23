    private void button_JogPLCVar_MouseDown(object sender, MouseEventArgs e)
    {
        Button button = (Button)sender;
        SetPLCVariable((string)button.Tag, true);
    }
    
    private void button_JogPLCVar_MouseUp(object sender, MouseEventArgs e
    {
        Button button = (Button)sender;
        SetPLCVariable((string)button.Tag, false);
    }
    private void SetPLCVariable(string fieldName, bool value)
    {
        Type type = typeof(PLCVars);
        FieldInfo fieldInfo = type.GetField(fieldName);
        fieldInfo.SetValue(PLCVariables, true);
    }
