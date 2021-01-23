    public class MyFirstClass : IMyInterface
    {
        private IDirectoryEntry _entryAccessor;
        public MyFirstClass(IDirectoryEntry entryAccessor)
        {
             _entryAccessor = entryAccessor;
        }
        public List<string> GetGroups()
        {
            var directoryEntry = _entryAccessor.Do(path);
            return something;
        }
    }
