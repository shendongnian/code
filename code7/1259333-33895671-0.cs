    public PcapStream
    {
        private Stream BaseStream;
        public PcapStream(Stream BaseStream)
        {
            this.BaseStream=BaseStream;
        }
        public void Write(RawCapture packet)
        {
            byte[] arr = new byte[packet.Data.Length + 16];
            byte[] sec = BitConverter.GetBytes((uint)packet.Timeval.Seconds);
            byte[] msec = BitConverter.GetBytes((uint)packet.Timeval.MicroSeconds);
            byte[] incllen = BitConverter.GetBytes((uint)packet.Data.Length);
            byte[] origlen = BitConverter.GetBytes((uint)packet.Data.Length);
            Array.Copy(sec, arr, sec.Length);
            int offset = sec.Length;
            Array.Copy(msec, 0, arr, offset, msec.Length);
            offset += msec.Length;
            Array.Copy(incllen, 0, arr, offset, incllen.Length);
            offset += incllen.Length;
            Array.Copy(origlen, 0, arr, offset, origlen.Length);
            offset += origlen.Length;
            Array.Copy(packet.Data, 0, arr, offset, packet.Data.Length);
            BaseStream.Write(arr, 0, arr.Length);
        }
