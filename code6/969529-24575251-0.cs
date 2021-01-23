    [ServiceContract]
    interface DNRIService 
    {
        [OperationContract]
        void OpenDnt(string path);
        [OperationContract]
        void OpenPak(string path);
        [OperationContract]
        bool IsOnline();
        [OperationContract]
        void Activate();
    }
