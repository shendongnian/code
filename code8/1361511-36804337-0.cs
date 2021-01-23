    private struct IntelliformMetaData
    {
        public readonly long ID;
        public readonly string OprINI;
        public readonly string FileReason;
        public readonly DateTime CreatedTime;
        public readonly byte[] header;
    
        public IntelliformMetaData(long pId, string pOprINI, string pFileReason, DateTime pCreatedTime, byte[] pHeader)
        {
            this.ID = pId;
            this.OprINI = pOprINI;
            this.FileReason = pFileReason;
            this.CreatedTime = pCreatedTime;
            this.header = pHeader;
        }
    }
