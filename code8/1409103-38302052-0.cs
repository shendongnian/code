    public class DeviceCommunication
    {
        bool FlagToProceed = false;
    
        private void MainJob()
        {
            // send command 1...
       
            // wait
            while(!FlagToProceed)
            {}
            // reset the flag
            FlagToProceed = false;
            // send command 2 ...
    
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
