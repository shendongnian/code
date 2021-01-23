    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        radioButton1.Visible = !checkBox1.Checked;
        LayoutRadioButtons();
    }
    private void LayoutRadioButtons()
    {
        var rbs = new RadioButton[]{radioButton1,radioButton2,radioButton3,radioButton4};
        location = 50;
        foreach(var rb in rbs)
        {
            if(rb.Visible)
            {
                radioButton1.Location = new Point(location , 40);
                location += 50
            }
        }
    }
