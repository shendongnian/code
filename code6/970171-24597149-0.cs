    public void ChangeTextBox(string txt)
        {
            if (!textBox1.Dispatcher.CheckAccess())
            {
                textBox1.Dispatcher.Invoke(new UpdateText(ChangeTextBox), new object[] { txt });
            }
            else
            {
                textBox1.Text += txt + "\r\n";
            }
        }
