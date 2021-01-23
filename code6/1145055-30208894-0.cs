    private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ThisCheckbox = (CheckBox)sender;
            if (ThisCheckbox.Checked == true)
            { 
                //finding the richtextbox by id...
                RichTextBox ThisRichtextbox = this.Controls.Find("TB" + ThisCheckbox.Name, true).FirstOrDefault() as RichTextBox;
                try//try and catch for testing, this can be removed later.
                {
                    MessageBox.Show(ThisRichtextbox.Text);
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message);
                }
            }
        }
