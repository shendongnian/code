    public class SerialPortReader
    {
        private const _filePath = @"C:\Users\Glenn\Desktop\data1.txt";
        private Int32 _lineNumber = 1;
    
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadLine();
            this.Invoke(new EventHandler(DisplayText));
            AppendToFile(RxString);
        }
    
        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(RxString + Environment.NewLine);
        }
    
        private void AppendToFile(string toAppend)
        {
            var line = String.Format("{0};{1}\n", toAppend, _lineNumber);
            File.AppendAllText(_filePath, line);
    	    _lineNumber++;
        }
    }
