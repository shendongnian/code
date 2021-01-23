    private void allButtons_Click(object sender, EventArgs e)
    {  
        Button btn = sender as Button;
        char c = btn.Text[0]; //assuming all buttons have exactly 1 character
        if(Char.IsDigit(c) || c == '.')
        {
            //process
            textBox1.Focus();
            SendKeys.Send(btn.Text);
        }
        //otherwise don't
    }
