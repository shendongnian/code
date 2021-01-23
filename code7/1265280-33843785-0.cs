    private void allButtons_Click(object sender, EventArgs e)
    {  
        Button button1 = sender as Button;
        char c = button1.Text[0];
        if(Char.IsDigit(c) || c == '.')
        {
            //process
            textBox1.Focus();
            SendKeys.Send(button1.Text);
        }
        //otherwise don't
    }
