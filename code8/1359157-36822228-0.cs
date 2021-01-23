      void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                int dataLength = _serialPort.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                if (nbrDataRead == 0)
                    return;
    
                // Send data to api
                string str = Encoding.ASCII.GetString(e.Data);
                    if (!string.IsNullOrEmpty(str))
                    {
                          var api = new HttpClient();
                          api.BaseUrl("http://somewhere.com");
                          api.PostAsJsonAsync("api/Something", str)
                    }
            }
 
    // i think this can go completely ...
    void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
