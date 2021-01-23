    public class MMFinterComT
    {
        public EventWaitHandle flagCaller1, flagCaller2, flagReciver1, flagReciver2;
        private System.IO.MemoryMappedFiles.MemoryMappedFile mmf;
        private System.IO.MemoryMappedFiles.MemoryMappedViewAccessor accessor;
        public virtual string DipositChlName { get; set; }
        public virtual string DipositThrdName { get; set; }
        public virtual int DipositSize { get; set; }
        private System.Threading.Thread writerThread;
        private bool writerThreadRunning;
        public int ReadPosition { get; set; }
        public List<string> statusSet;
        private int writePosition;
        public int WritePosition
        {
            get { return writePosition; }
            set
            {
                if (value != writePosition)
                {
                    this.writePosition = value;
                    this.accessor.Write(WritePosition + READ_CONFIRM_OFFSET, true);
                }
            }
        }
        private List<byte[]> dataToSend;
        private const int DATA_AVAILABLE_OFFSET = 0;
        private const int READ_CONFIRM_OFFSET = DATA_AVAILABLE_OFFSET + 1;
        private const int DATA_LENGTH_OFFSET = READ_CONFIRM_OFFSET + 1;
        private const int DATA_OFFSET = DATA_LENGTH_OFFSET + 10;
        public IpcMMFinterComSF.MMFinterComTStatus IntercomStatus;
        public MMFinterComT(string ctrIpcChannelNameStr, string ctrIpcThreadName, int ctrMMFSize)
        {
            this.DipositChlName = ctrIpcChannelNameStr;
            this.DipositSize = ctrMMFSize;
            this.DipositThrdName = ctrIpcThreadName;
            mmf = MemoryMappedFile.CreateOrOpen(DipositChlName, DipositSize);
            accessor = mmf.CreateViewAccessor(0, DipositSize, System.IO.MemoryMappedFiles.MemoryMappedFileAccess.ReadWrite);//if (started)
            //smLock = new System.Threading.Mutex(true, IpcMutxName, out locked);
            ReadPosition = -1;
            writePosition = -1;
            this.dataToSend = new List<byte[]>();
            this.statusSet = new List<string>();
        }
        public bool reading;
        public byte[] ReadData;
        public void StartReader()
        {
            if (this.IntercomStatus != IpcMMFinterComSF.MMFinterComTStatus._Null || ReadPosition < 0 || writePosition < 0)
                return;
            this.IntercomStatus = IpcMMFinterComSF.MMFinterComTStatus.PreparingReader;
            System.Threading.Thread t = new System.Threading.Thread(ReaderThread);
            t.IsBackground = true;
            t.Start();
         
        }
        private void ReaderThread(object stateInfo)
        {
                // Checks if there is something to read.
            this.IntercomStatus = IpcMMFinterComSF.MMFinterComTStatus.TryingToRead;
                this.reading = accessor.ReadBoolean(ReadPosition + DATA_AVAILABLE_OFFSET);
                if (this.reading)
                {
                    this.IntercomStatus = IpcMMFinterComSF.MMFinterComTStatus.ReadingData;
                    // Checks how many bytes to read.
                    int availableBytes = accessor.ReadInt32(ReadPosition + DATA_LENGTH_OFFSET);
                    this.ReadData = new byte[availableBytes];
                    // Reads the byte array.
                    int read = accessor.ReadArray<byte>(ReadPosition + DATA_OFFSET, this.ReadData, 0, availableBytes);
                    // Sets the flag used to signal that there aren't available data anymore.
                    accessor.Write(ReadPosition + DATA_AVAILABLE_OFFSET, false);
                    // Sets the flag used to signal that data has been read. 
                    accessor.Write(ReadPosition + READ_CONFIRM_OFFSET, true);
                    this.IntercomStatus = IpcMMFinterComSF.MMFinterComTStatus.FinishedReading;
                }
                else this.IntercomStatus = IpcMMFinterComSF.MMFinterComTStatus._Null;
        }
        public void Write(byte[] data)
        {
            if (ReadPosition < 0 || writePosition < 0)
                throw new ArgumentException();
            this.statusSet.Add("ReadWrite:-> " + ReadPosition + "-" + writePosition);
            lock (this.dataToSend)
                this.dataToSend.Add(data);
            if (!writerThreadRunning)
            {
                writerThreadRunning = true;
                writerThread = new System.Threading.Thread(WriterThread);
                writerThread.IsBackground = true;
                writerThread.Name = this.DipositThrdName;
                writerThread.Start();
            }
        }
        public void WriterThread(object stateInfo)
        {
            while (dataToSend.Count > 0 && !this.disposed)
            {
                byte[] data = null;
                lock (dataToSend)
                {
                    data = dataToSend[0];
                    dataToSend.RemoveAt(0);
                }
                while (!this.accessor.ReadBoolean(WritePosition + READ_CONFIRM_OFFSET))
                    System.Threading.Thread.Sleep(133);
                // Sets length and write data.
                this.accessor.Write(writePosition + DATA_LENGTH_OFFSET, data.Length);
                this.accessor.WriteArray<byte>(writePosition + DATA_OFFSET, data, 0, data.Length);
                // Resets the flag used to signal that data has been read.
                this.accessor.Write(writePosition + READ_CONFIRM_OFFSET, false);
                // Sets the flag used to signal that there are data avaibla.
                this.accessor.Write(writePosition + DATA_AVAILABLE_OFFSET, true);
            }
            writerThreadRunning = false;
        }
        public virtual void Close()
        {
            if (accessor != null)
            {
                try
                {
                    accessor.Dispose();
                    accessor = null;
                }
                catch { }
            }
            if (this.mmf != null)
            {
                try
                {
                    mmf.Dispose();
                    mmf = null;
                }
                catch { }
            }
            disposed = true;
            GC.SuppressFinalize(this);
        }
        private bool disposed;
    }
