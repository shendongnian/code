      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         Thread t = new Thread(() =>
         {
            Thread.Sleep(10000);
            Debug.WriteLine("I am still alive!!!  So I can still kill the processes here");
            // After this point, the process shuts down, because this was the last thread running.
         });
         t.Start();
         // at this point, the form will close, but the process is still alive as long as thread `t` is alive.
      }
