    /// <summary>
    /// Exception that returns an ICIO error wrapped in an exception.
    /// </summary>
    internal class ICIOErrorException : COMException {
        internal ICIOErrorException(ICIO.IOErrors errorCode, string message)
            : base(message) {
            this.HResult = (int)(0x800A0000 | (int)errorCode);
        }
    }
