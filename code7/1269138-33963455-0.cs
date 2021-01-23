    private void ValidateButton_Click(object sender, EventArgs e)
        {
            Boolean checkboxFlag = false;
            foreach (var control in this.Controls)
            {
                if (control is CheckBox)
                {
                    if (((CheckBox) control).Checked)
                    {
                        checkboxFlag = true;
                        validatebutton.hide();
                        nextbutton.show();
                    }
                }
            }
        if(!checkboxFlag)
            {
                DialogResult uncheckederror = MessageBox.Show("You must select at least one checkbox",
                    "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }
