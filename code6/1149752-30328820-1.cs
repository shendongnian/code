        [ServiceContract]
        public interface IFileWriter
        {
            [OperationContract]
            void Open(string file);
    
            [OperationContract(IsOneWay = true)]
            void Write(byte[] buffer);
    
            [OperationContract]
            void Close();
        }
