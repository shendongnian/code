    private Label SelectedLabel; //don't initialize here (also note the name change)
    
    public void btnAddCharacter_Click(object sender, EventArgs e)
    {
        //do it here:
        var ctrLabel = new Label();
        ctrLabel.Name = "Lbl_";
        ctrLabel.Text = txtIDImg.Text;
        ctrLabel.BackColor = Color.Transparent;
        // In each of these events, add a line at the very top that looks like this:
        //   var ctrLabel = sender as Label;
        //Assuming their purpose is mark which label is selected, 
        //  you can now set the "SelectedLabel" variable above to the correct object
        ctrLabel.MouseEnter += new EventHandler(control_MouseEnter);
        ctrLabel.MouseLeave += new EventHandler(control_MouseLeave);
        ctrLabel.MouseDown += new MouseEventHandler(control_MouseDown);
        ctrLabel.MouseMove += new MouseEventHandler(control_MouseMove);
        ctrLabel.MouseUp += new MouseEventHandler(control_MouseUp);
        panel2.Controls.Add(ctrLabel);
    }
    // And now these two methods can also use the "SelectedLabel" variable
    //   and when they do, the correct object will be affected
    private void cbxFontSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedLabel.Font = new Font(ctrLabel.Font.FontFamily, Convert.ToInt32(cbxFontSize.SelectedItem),
            SelectedLabel.Font.Style);
    }
    private void cbxFont_TextChanged(object sender, EventArgs e)
    {
        SelectedLabel.Font = new Font(cbxFont.Text, SelectedLabel.Font.Size, SelectedLabel.Font.Style);
    }
