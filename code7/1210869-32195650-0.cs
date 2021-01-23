    public interface ICallBack
    {
        /// <summary>
        /// The Child Callback must override this method and this will be fired when time comes
        /// </summary>
        /// <param name="files">The resultant files </param>
        /// <param name="code">Error code</param>
        void GotFileList(FileType type, IList<Object> files, ErrorCode code);
    }
