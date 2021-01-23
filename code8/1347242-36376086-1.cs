    private void AddButton_Click(object sender, EventArgs e)
    {
       int first = 0;
       int second = 0;
       //Use TryParse() method to avoid exceptions while parsing an invalid string
       int.TryParse(FirstOperandTextBox.Text, out first);
       int.TryParse(SecondOperandTextBox.Text, out second);
       //in the left hand side of = operator, there **must** be a variable always.
       result = first + second;
       ResultTextBox.Text = result.ToString();
    }
