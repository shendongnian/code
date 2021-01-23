    public void request_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        ClsComSettingMain clsComSettingMain = (ClsComSettingMain)e.Argument;
        string comPort = clsComSettingMain.comport;
        int baudRate = clsComSettingMain.baudRate;
    
        if (comPort != null && baudRate != 0)
        {
            SerialPort serialPort = new SerialPort(comPort, baudRate);
            serialPort.Open();
    
            while (true)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    serialPort.Write(adv_request, 0, 3); // Write byte array to serial port, with no offset, all 3 bytes
                    Thread.Sleep(500);
                }
            }
        }
    
    }
