    protected void InsertNumber(int number)
    {
        int numberCount = 0;
        
        for (int i = 0; i < CurrentInput.Text.Length; i++)
        {
            try
            {
                if (Enumberable.Range(0, 9).Contains(Convert.ToInt32(CurrentInput.Text.Substring(i, 1))))
                {
                    numberCount++;
                }
            }
            catch
            {
                // Do nothing?
            }
        }
        
        if (numberCount <= 9)
        {
            if (OP.Text == "=")
            {
                Result.Text = CurrentInput.Text;
                CurrentInput.Text = number.ToString();
            }
            else
            {
                CurrentInput.Text += number.ToString();
            }
        }
    }
    
    // Exacmple usage, apply to all buttons
    protected void Nine_OnClick(object sender, EventArgs e)
    {
        InsertNumber(9);
    }
