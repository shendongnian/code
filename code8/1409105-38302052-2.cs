    public class DeviceCommunication
    {
        bool FlagToProceed = false;
    
        private void MainJob()
        {
            // send command 1...
            SerialDataSend("cp tftp://10.0.0.1/file.tgz /var/tmp/file.tgz.");
       
            // wait
            while(!FlagToProceed)
            {}
            // reset the flag
            FlagToProceed = false;
            // send command 2 ...
            SerialDataSend("WhatEverComesNext");    
            // wait
            while(!FlagToProceed)
            {}    
            // reset the flag
            FlagToProceed = false;
    
        }
        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
              SerialPort serialPort = (SerialPort)sender;
              strDataReceived = serialPort.ReadExisting();                
              ShowSerialOutput(strDataReceived); 
    
              // check whether affirmation has been received and open the gates
              if(strDataReceived.Contains("completed"))
              {   
                  FlagToProceed = true;
              }                  
        }
    
        private void SerialDataSend(string strCommand)
        {
              serialPort.WriteLine(strCommand);   
        }    
    }
