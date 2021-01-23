    public void GetData(string message)
    {
        label1.Invoke((MethodInvoker) delegate
        {
             label1.Text = message;     
        });
        MessageBox.Show(message);   
    }
    
