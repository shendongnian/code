    private Label SelectedLabel; //don't initialize here (also note the name change)
    
    public void btnAddCharacter_Click(object sender, EventArgs e)
    {
        //do it here:
        var ctrLabel = new Label();
        ctrLabel.Name = "Lbl_";
        ctrLabel.Text = txtIDImg.Text;
        ctrLabel.BackColor = Color.Transparent;
        // In each of these events, add a line at the very top that looks like this:
        //     var ctrLabel = sender as Label;
        ctrLabel.MouseEnter += new EventHandler(control_MouseEnter);
        ctrLabel.MouseLeave += new EventHandler(control_MouseLeave);
        ctrLabel.MouseDown += new MouseEventHandler(control_MouseDown);
        ctrLabel.MouseMove += new MouseEventHandler(control_MouseMove);
        ctrLabel.MouseUp += new MouseEventHandler(control_MouseUp);
        panel2.Controls.Add(ctrLabel);
    }
    // Somewhere (perhaps in the events above) you have code that decides
    // which control is selected. Now, instead of `ctrLabel`, you track this
    // assigning to the `SelectedLabel` variable. Then the two methods below
    // can look like this:
    private void cbxFontSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SelectedLabel == null) return;
        SelectedLabel.Font = new Font(ctrLabel.Font.FontFamily, Convert.ToInt32(cbxFontSize.SelectedItem),
            SelectedLabel.Font.Style);
    }
    private void cbxFont_TextChanged(object sender, EventArgs e)
    {
        if (SelectedLabel == null) return;
        SelectedLabel.Font = new Font(cbxFont.Text, SelectedLabel.Font.Size, SelectedLabel.Font.Style);
    }
