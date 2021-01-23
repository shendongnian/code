     private void Form1_DoubleClick(object sender, MouseEventArgs e)
        {
          // Send the enter key; since the tab stop of Button1 is 0, this 
          // will trigger the click event.
          SendKeys.SendWait("{ENTER}");
          CallAfterSend();
        }
    
        private void CallAfterSend()
        {
          MessageBox.Show("Had to hit enter first");
        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
          MessageBox.Show("Click here!");
        }
      
