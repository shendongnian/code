    var checkBoxStates = groupBox.Controls
        .OfType<CheckBox>
        .Where(x => x.Name.StartsWith("CheckBox"))
        .Select(x => new {
            Index = Int.Parse(x.Name.Substring("CheckBox".Length)), 
            IsChecked = x.Checked
        })
        .ToList();
    var comboBoxStates = groupBox.Controls
        .OfType<ComboBox>
        .Where(x => x.Name.StartsWith("ComboBox"))
        .Select(x => new {
            Index = Int.Parse(x.Name.Substring("ComboBox".Length)), 
            IsEmpty = x.Items.Count == 0
        })
        .ToList();
