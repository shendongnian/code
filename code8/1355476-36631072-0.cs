    public class CancellableJsonTextReader : JsonTextReader
    {
        protected Func<bool> CheckCancelled { get; set; }
        public CancellableJsonTextReader(TextReader reader, Func<bool> checkCancelled)
            : base(reader)
        {
            this.CheckCancelled = checkCancelled;
        }
        public bool IsCancelled { get; private set; }
        public override bool Read()
        {
            DoCheckCancelled();
            return base.Read();
        }
        public override bool? ReadAsBoolean()
        {
            DoCheckCancelled();
            return base.ReadAsBoolean();
        }
        public override byte[] ReadAsBytes()
        {
            DoCheckCancelled();
            return base.ReadAsBytes();
        }
        public override DateTime? ReadAsDateTime()
        {
            DoCheckCancelled();
            return base.ReadAsDateTime();
        }
        public override DateTimeOffset? ReadAsDateTimeOffset()
        {
            DoCheckCancelled();
            return base.ReadAsDateTimeOffset();
        }
        public override decimal? ReadAsDecimal()
        {
            DoCheckCancelled();
            return base.ReadAsDecimal();
        }
        public override double? ReadAsDouble()
        {
            DoCheckCancelled();
            return base.ReadAsDouble();
        }
        public override int? ReadAsInt32()
        {
            DoCheckCancelled();
            return base.ReadAsInt32();
        }
        public override string ReadAsString()
        {
            DoCheckCancelled();
            return base.ReadAsString();
        }
        private void DoCheckCancelled()
        {
            if (!IsCancelled && CheckCancelled != null)
                IsCancelled = CheckCancelled();
            if (IsCancelled)
            {
                throw new JsonReaderCancelledException();
            }
        }
    }
    public class JsonReaderCancelledException : JsonReaderException
    {
        public JsonReaderCancelledException() { }
        public JsonReaderCancelledException(string message)
            : base(message)
        {
        }
        public JsonReaderCancelledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public JsonReaderCancelledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
