    interface IFile
    {
        void Save();
    }
    interface IDatabaseRecord
    {
        void Save();
    }
    class Customer : IFile, IDatabaseRecord
    {
        public void Save()
        {
            //what to do here?
        }
    }
