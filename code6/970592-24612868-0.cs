    private void UpdateUnitLabels(GroupBox groupBox, string unit)
    {
        foreach (Control control in groupBox.Controls)
        {
            var label = control as Label;
            if (Label != null)
            {
                label.Text = unit;
            }
        }
    }
