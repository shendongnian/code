        List<byte> tmpBuffer = new List<byte>();
        static byte newLineB = Encoding.ASCII.GetBytes("\n")[0];
        void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            lock (tmpBuffer)
            {
                while (serial.BytesToRead > 0)
                {
                    byte[] segment = new byte[serial.BytesToRead];
                    serial.Read(segment, 0, segment.Length);
                    tmpBuffer.AddRange(segment);
                    ProcessBuffer();
                }
            }
        }
        private void ProcessBuffer()
        {
            int index = 0;
            while ((index = tmpBuffer.IndexOf(newLineB)) > -1)
            {
                string line = Encoding.ASCII.GetString(tmpBuffer.Take(index + 1).ToArray());
                //Do whatever you need to do with the line data
                Debug.WriteLine(line);
                tmpBuffer.RemoveRange(0, index + 1);
            }
        }
