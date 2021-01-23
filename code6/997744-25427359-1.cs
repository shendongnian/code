    public void passMessage(object s, EventArgs e)
    {
       txtMessage.Invoke(delegate()
       {
          txtMessage.Text = "";
       });
    }
