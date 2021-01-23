       private delegate void MyDelegate(int param);
       private void MyFunc(int aParam)
       {     
          // Invoke is required if we aren't on the GUI thread
          if (this.InvokeRequired)
          {
             // MyFunc will be called asynchronously on the
             // GUI thread.
             //
             this.BeginInvoke(new MyDelegate(MyFunc), 
                                              new object[] {aParam});
             return;
          }
          // We only get here if we're running on the GUI thread
          // So we can put GUI ops here safely.
        }
