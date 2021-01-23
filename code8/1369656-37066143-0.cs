    private void btnIncrement_Click(object sender, System.EventArgs e)
    {
      Increment();
    }
    protected override bool ProcessCmdKey(Message msg, Keys keyData)
    {
      if (keyData == (Keys.Ctrl | Keys.Oemplus) {
        Increment();
      }
      return base.ProcessCmdKey(msg, keyData);
    } 
    private void Increment()
    {
      //Do what needs to be done in this case
    }
