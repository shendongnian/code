    int controlCount;
    if (int.TryParse(textBox1.Text.Trim(), out controlCount)
        && controlCount > 0 && controlCount <= controls.Length)
    {
        var activeControls = controls.Take(controlCount);
        var unactiveControls = controls.Skip(controlCount);
        foreach (Control activeControl in activeControls)
        {
            activeControl.BackColor = Color.DarkRed;
            activeControl.Visible = true;
        }
        foreach (Control unactiveControl in unactiveControls)
        {
            unactiveControl.BackColor = Color.Black;
            unactiveControl.Visible = false;
        }
    }
