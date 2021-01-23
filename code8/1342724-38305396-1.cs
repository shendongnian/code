    class HikFileStream : FileStream
    {
        public HikFileStream(string path)
            : base(path, FileMode.Create, FileAccess.Write, FileShare.None)
        {
        }
        public long CurrentSize { get; private set; }
        public event EventHandler Progress;
        public override void Write(byte[] array, int offset, int count)
        {
            base.Write(array, offset, count);
            CurrentSize += count;
            var h = Progress;
            if (h != null)
                h(this, EventArgs.Empty);//WARN: THIS SHOULD RETURNS ASAP!
        }
    }
