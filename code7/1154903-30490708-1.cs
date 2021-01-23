    private void button_Click(object sender, EventArgs e)
    {
        if (textBox_Result.Text == "0" || isOperationPerformed)
            textBox_Result.Clear();
        isOperationPerformed = false;
        Button button = (Button)sender;
        if(button.Text == ".")
        {
            if(!textBox_Result.Text.Contains("."))
                textBox_Result.Text = textBox_Result.Text + button.Text;
        }
        else
            textBox_Result.Text = textBox_Result.Text + button.Text;
        
        labelCurrentOperation.Text = labelCurrentOperation.Text + " " + button.Text;
    }
    private void operator_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (resultVal != 0)
        {
            button16.PerformClick();
            operationPerformed = button.Text;
            labelCurrentOpration.Text = labelCurrentOpration.Text + " " + resultVal + " " + operationPerformed;
            isOperationPerformed = true;
        }
        else
        {
            operationPerformed = button.Text;
            resultVal = Double.Parse(textBox_Result.Text);
            labelCurrentOpration.Text = labelCurrentOpration.Text + " " + resultVal  + " " + operationPerformed;
                isOperationPerformed = true;
        }
    }
