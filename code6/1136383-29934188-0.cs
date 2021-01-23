    if (textBoxX1.Text == String.Empty)
        MessageBox.Show("You must enter a title.");
    else if (richTextBoxEx1.Text == String.Empty)
        MessageBox.Show("You must enter a body.");
    else
    {
        MessageBoxIcon previewtype;
        MessageBoxButtons previewbutton;
        if (radioButton1.Checked == true)
            previewtype = MessageBoxIcon.Error;
        else if (radioButton2.Checked == true)
            previewtype = MessageBoxIcon.Information;
        else if (radioButton3.Checked == true)
            previewtype = MessageBoxIcon.Exclamation;
        else if (radioButton4.Checked == true)
            previewtype = MessageBoxIcon.Question;
        if (radioButton8.Checked == true)
            previewbutton = MessageBoxButtons.AbortRetryIgnore;
        else if (radioButton7.Checked == true)
            previewbutton = MessageBoxButtons.OK;
        else if (radioButton6.Checked == true)
            previewbutton = MessageBoxButtons.OKCancel;
        else if (radioButton5.Checked == true)
            previewbutton = MessageBoxButtons.RetryCancel;
        else if (radioButton9.Checked == true)
            previewbutton = MessageBoxButtons.YesNo;
        else if (radioButton10.Checked == true)
            previewbutton = MessageBoxButtons.YesNoCancel;
        MessageBox.Show(textBoxX1.Text, richTextBoxEx1.Text, previewbutton, previewtype);
