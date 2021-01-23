    /// <summary> CheckedSerialPort class checks that read and write operations are only performed by the thread owning the lock on the serial port </summary>
    // Just check reads and writes (not basic properties, opening/closing, or buffer discards). 
    public class CheckedSerialPort : SafePort /* derived in turn from SerialPort */
    {
        private void checkOwnership()
        {
            try
            {
                if (Monitor.IsEntered(XXX_Conn.SerialPortLockObject)) return; // the thread running this code has the lock; all set!
                // Ooops...
                throw new Exception("Serial IO attempted without lock ownership");
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder("");
                sb.AppendFormat("Message: {0}\n", ex.Message);
                sb.AppendFormat("Exception Type: {0}\n", ex.GetType().FullName);
                sb.AppendFormat("Source: {0}\n", ex.Source);
                sb.AppendFormat("StackTrace: {0}\n", ex.StackTrace);
                sb.AppendFormat("TargetSite: {0}", ex.TargetSite);
                Console.Write(sb.ToString());
                Debug.Assert(false); // lets have a look in the debugger NOW...
            }
        }
        public new int ReadByte()                                       { checkOwnership(); return base.ReadByte(); }
        public new string ReadTo(string value)                          { checkOwnership(); return base.ReadTo(value); }
        public new string ReadExisting()                                { checkOwnership(); return base.ReadExisting(); }
        public new void Write(string text)                              { checkOwnership(); base.Write(text); }
        public new void WriteLine(string text)                          { checkOwnership(); base.WriteLine(text); }
        public new void Write(byte[] buffer, int offset, int count)     { checkOwnership(); base.Write(buffer, offset, count); }
        public new void Write(char[] buffer, int offset, int count)     { checkOwnership(); base.Write(buffer, offset, count); }
    }
