    async void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                //// Fired-off asynchronously; let the current thread continue.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }
            //data is converted to text
            string str = Encoding.ASCII.GetString(e.Data);
            if (!string.IsNullOrEmpty(str))
            {
               await CallWebservice(str)
            }
        }
