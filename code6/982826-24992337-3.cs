    private void startButton_Click(object sender, EventArgs e)
    {
        startButton.Enabled = false;
        pathTextBox.Enabled = false;
        using (Form1 form1 = new Form1(pathTextBox.Text))
        {
             // ShowDialog is required to stop the execution here 
             // Otherwise the code exits immediately and the using destroys the form1 instance
             form1.ShowDialog();
        }
    }
