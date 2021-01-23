    class Customer : IFile, IDatabaseRecord
    {
        void IFile.Save() { }
        void IDatabaseRecord.Save() { }
    }
