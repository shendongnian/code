    private CancellationTokenSource tokenSource; //global field
    
    public void ClientReceive()
    {
        try
        {
    		//initiate CancellationTokenSource
    		tokenSource = new CancellationTokenSource();
    		
            stream = client.GetStream(); //Gets The Stream of The Connection
            
    		//start parallel task
    		Task.Factory.StartNew(() =>
            {			
    			//MessageBox.Show(stream.Read(datalength, 0, 256).ToString());
                //(i = stream.Read(datalength, 0, 256)) != 0
                while (i != 1)//Keeps Trying to Receive the Size of the Message or Data
                {
                    // how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                    // byte[] data = BitConverter.GetBytes(1000); // Creates a Byte for the data to be Received On
                    byte[] data = new byte[1000];
                    stream.Read(data, 0, data.Length); //Receives The Real Data not the Size
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {
                        //txtLog.Text += System.Environment.NewLine + "Server : " + Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String
                        DateTime now = DateTime.Now;
                        //MessageBox.Show(Encoding.Default.GetString(data));
                        if (Encoding.Default.GetString(data) != "")
                        {
                            txtLog.Text += System.Environment.NewLine + now.ToString() + " Received : \r\n" + Encoding.Default.GetString(data) + "\r\n";
    
                        }
                        for (int j = 0; j < txtLog.Lines.Length; j++)
                        {
                            if (txtLog.Lines[j].Contains("Received"))
                            {
                                this.CheckKeyword(txtLog.Lines[j + 1], Color.Red, 0);
                            }
                            if (txtLog.Lines[j].Contains("Sent"))
                            {
                                this.CheckKeyword(txtLog.Lines[j + 1], Color.Blue, 0);
                            }
                        }
    
                    });
                }
            }, tokenSource.Token);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());  
        }
    }
    
    //call this method on cancel button
    private void cancelTask()
    {
    	if(tokenSource != null)	//check if its even initialized or not
    		tokenSource.Cancel();
    }
