    private void brnContinue_Click(object sender, EventArgs e)
    {
      Worker workerObject = new Worker(this);
      Task.Factory.StartNew(() =>
      {
        //workerObject.DoWork();  // CrossThreadException
        Invoke(new MethodInvoker(workerObject.DoWork));  // OK
      });
    }
