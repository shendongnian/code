    private bool inputBoxProcedure(string text, string defaulttext)
    {
        InputBoxResult result = InputBox.Show(text, "Hours Entry", defaulttext, new InputBoxValidatingHandler(inputBox_Validating));
        if (result.OK)
        {
            labelHoursWorked.Text = result.Text.Trim();
        }
        else
        {
            if (MessageBox.Show("Input was cancelled. Do you wish to quit the application?", "Input Cancelled", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                buttonReset_Click(this, new EventArgs());
                //Form fr = new Form();
                //fr.Show();
                //this.Close();
                //Application.Restart();
                return false; // Added
            }
        }
        return true; // Added
    }
