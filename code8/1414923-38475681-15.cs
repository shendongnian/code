    public class Factory : IFactory
    {
        private readonly Func<string, IWriter> _createFunc;
    
        public Factory(Func<string, IWriter> createFunc)
        {
            _createFunc = createFunc;
        }
    
        public IWriter CreateScope(string writesTo)
        {
            return _createFunc(writesTo);
        }
    }
