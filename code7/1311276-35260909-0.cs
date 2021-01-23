    private void groupBox_Validating(object sender, CancelEventArgs e)
    {
        if (sender is RadioButton)
        {
            e.Cancel = !checkBox1.Checked;
        }
        count++;
        //Display the number of times validating is called in the title bar
        //Demonstrates when the event is called
        Text = count.ToString();
    }
