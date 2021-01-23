    int numberOfVlcVariables = typeof(PLCVars).GetProperties()
          .Count(p => p.Name.StartsWith("PLCVar"));
    for(int i = 1; numberOfVlcVariables <= ; i++)
    {
        CheckBox cb = new CheckBox();
        cb.Appearance = Appearance.Button;
        cb.Text = "PLCVar" + i;
        cb.DataBindings.Add("Checked", PLCVariables, "PLCVar" + i);
        flowLayoutPanel1.Controls.Add(cb);
    }
