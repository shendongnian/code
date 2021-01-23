     // convert your input only once
     int myNumber = Convert.ToInt32(textBox1.Text);
     // pad with the maximum possible length, plus one space
     int padAmount = (myNumber * myNumber).ToString().Length + 1; 
     for (int i = 1; i <= myNumber; i++)
     {
       for (int j = 1; j <= myNumber; j++)
       {
         // pad your input by the amount of spaces needed to fit all possible numbers
         richTextBox1.Text += (i*j).ToString().PadLeft(padAmount);
       }
     }
     // use Environment.NewLine instead of `\n`
     richTextBox1.Text += Environment.NewLine;
