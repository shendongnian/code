    List<Label> customLabels = new List<Label>();
    
    foreach (string ValutaCustomScelta in Properties.Settings.Default.ValuteCustom)
    {
        Label label = new Label();
        label.Location = new System.Drawing.Point(317, 119 + customLabels.Count*26);
        label.Parent = tabPage2;
        label.Name = "label" + ValutaCustomScelta;
        label.Text = ValutaCustomScelta;
        label.Size = new System.Drawing.Size(77, 21);
        customLabels.Add(label);
        Page2.Controls.Add(label);
    }
