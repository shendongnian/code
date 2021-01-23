    List<int> acceptedValues = new List<int>(){ 1, 2, 3, 4, 6, 12 };
    
    private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
    {
        int number = numericUpDown1.Value;
        if (acceptedValues.Contains(number) || (number % 24 == 0))
        {
           // is good
        }
    }
    
    private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right) 
        {
           int number = numericUpDown1.Value;
           if (acceptedValues.Contains(number) || (number % 24 == 0))
           {
              // is good
           }
        }
    }
