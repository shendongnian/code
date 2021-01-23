        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // this the read buffer
            byte[] buff = new byte[9600];
            int readByteCount = sp.BaseStream.Read(buff, 0, sp.BytesToRead);
            // you can specify other encodings, or use default
            string response = System.Text.Encoding.UTF8.GetString(buff);
            // you need to implement AppendToFile ;)
            AppendToFile(String.Format("response :{0}",response));
            // Or, just send sp.ReadExisting();
            AppendToFile(sp.ReadExisting());
        }
