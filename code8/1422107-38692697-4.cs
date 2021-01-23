    class FileBroker : IBroker<FileHandlerMessage>
    {
        public void Process(FileHandlerMessage message)
        {
            throw new NotImplementedException();
        }
    }
    class TimeBroker : IBroker<TimeHandlerMessage>
    {
        public void Process(TimeHandlerMessage message)
        {
            throw new NotImplementedException();
        }
    }
