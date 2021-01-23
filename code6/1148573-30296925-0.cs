        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
            if (e.EventType == System.IO.Ports.SerialData.Eof) return;
            // Rest of code
            //...
        }
