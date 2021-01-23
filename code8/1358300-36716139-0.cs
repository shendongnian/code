    public void WriteMessages(string message)
    { 
      if (InvokeRequired)
      { this.Invoke(new Action<string>(WriteMessages), new object[] { message }); }
      else
      { textBox_Messages.AppendText("SYSTEM: " + message + "\n"); }
    }
