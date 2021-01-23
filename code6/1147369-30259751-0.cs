    public void update(string message)
    {
        richTextBox1.Invoke(
          (MethodInvoker) delegate 
          { 
              richTextBox1.Text = message; 
          });
    }
