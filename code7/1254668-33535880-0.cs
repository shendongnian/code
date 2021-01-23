    List<ComboBox> ComboBoxes = groupBox1
        .Controls
        .OfType<ComboBox>()
        .Select((control) => control).ToList();
    
    foreach (var c in ComboBoxes)
    {
        Console.WriteLine(c.Name);
    }
    
    string nameOfComboBox = "comboBox1";
    ComboBox findThis = groupBox1
        .Controls
        .OfType<ComboBox>()
        .Select((control) => control)
        .Where(control => control.Name == nameOfComboBox)
        .FirstOrDefault();
    
    if (findThis != null)
    {
        Console.WriteLine(findThis.Text);
    }
    else
    {
        Console.WriteLine("Not found");
    }
