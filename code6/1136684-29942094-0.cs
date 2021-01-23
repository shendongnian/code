    private void genButton_Click(object sender, EventArgs e)
    {
        // Assuming your text box name. Also assuming UI disables button until text is entered.
        this.CreateQRImage(myTextBox.Text);
    }
