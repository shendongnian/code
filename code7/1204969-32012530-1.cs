    Task.Factory.StartNew(() =>
    {
         for (int i = 0; i < 10; i++)
         {              
              Invoke(new MethodInvoker(() => label9.Text = "Processing " + i.ToString()));
              Thread.Sleep(1000);
         }
    });
