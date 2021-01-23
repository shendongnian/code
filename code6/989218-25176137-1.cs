    RadioButton checkedButton;
    void radioButton_CheckedChanged(object sender, EventArgs e)
    {
    	RadioButton tempRdBtn = sender as RadioButton;
    	if (tempRdBtn.Checked)
    		checkedButton = tempRdBtn;
    }
