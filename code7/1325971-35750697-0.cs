    public class CustomBinaryWriter : ApprovalBinaryWriter
    {
        private readonly int _index;
        public CustomBinaryWriter(byte[] data, string extensionWithoutDot, int index)
            : base(data, extensionWithoutDot)
        {
            _index = index;
        }
        public override string GetApprovalFilename(string basename)
        {
            return string.Format("{0}_{1}{2}{3}", basename, _index, WriterUtils.Approved, ExtensionWithDot);
        }
        public override string GetReceivedFilename(string basename)
        {
            return string.Format("{0}_{1}{2}{3}", basename, _index, WriterUtils.Received, ExtensionWithDot);
        }
    }
