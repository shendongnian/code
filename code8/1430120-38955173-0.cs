    private async Task sendToPort(string sometext)
        {
    using (SerialDevice serialPort = await SerialDevice.FromIdAsync(deviceId))
            {
                Task.Delay(1000).Wait(); 
                if ((serialPort != null) && (sometext.Length != 0))
                {
                    serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
                    serialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = SerialParity.None;
                    serialPort.StopBits = SerialStopBitCount.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = SerialHandshake.None;
                    Task.Delay(1000).Wait();
                    try
                    {
    using (DataWriter dataWriteObject = new DataWriter(serialPort.OutputStream))
                        {
                            Task<UInt32> storeAsyncTask;
                            dataWriteObject.WriteString(sometext);
                            storeAsyncTask = dataWriteObject.StoreAsync().AsTask();
                            UInt32 bytesWritten = await storeAsyncTask;
                            if (bytesWritten > 0)
                            {
                                txtStatus.Text = bytesWritten + " bytes written";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        txtStatus.Text = ex.Message;
                    }
                }
            }
        }
