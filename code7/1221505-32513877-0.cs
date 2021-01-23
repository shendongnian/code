      private void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
          Thread.Sleep(100); // Why do you need to wait for 100 ms? If the event reaches here, it will have the data to read. Can remove?
          try
          {
              SerialPort sp = (SerialPort)sender;
              SerialString = sp.ReadExisting();
              this.Invoke(new EventHandler(Analisa));
          }
          catch (Exception ex)
          {
               // Do something else
               Console.WriteLine(ex.Message);
          }
               
      }
