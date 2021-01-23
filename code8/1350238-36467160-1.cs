      public void UpdateTimeLog(string input)
            {
                string timeNumber = "txtTime" + input;
               // TextBox myTextbox = (TextBox)FindControl(timeNumber);
                Control[] allControls = FlattenHierachy(Page);
                foreach (Control control in allControls)
                {
                    TextBox textBox = control as TextBox;
                    if (textBox != null && textBox.ID == timeNumber)
                    {
                        textBox.Text = "Hello";//Do your other stuff
                    }
                }
    
              //Rest is ommited
            }
