      private void timer1_Tick_1(object sender, EventArgs e)
      {
          SendKeys.SendWait("^c");
          Application.DoEvents();
    
          if (Clipboard.ContainsText())
          {
              var lText = Clipboard.GetText();
              textBox1.AppendText(lText);
          }
      }
