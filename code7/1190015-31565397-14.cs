    public class Form1
    {
        pcbSerialPort PCB; // The name of that class I don't know from your code
        public Form1()
        {
            PCB = new pcbSerialPort();
            PCB.MessageReceived += MessageReceived;
        } 
        private void MessageReceived(object sender, pcbSerialPort.MessageReceivedEventArgs e)
        {
            analyzeIncomingMessage(e.Data);
        }
    
        private void analyzeIncomingMessage(byte[] data)
        {
            if (data[0] == 63)
            {
                setBoardDesignator(data[1], data[2]);
            }
        }
    }
