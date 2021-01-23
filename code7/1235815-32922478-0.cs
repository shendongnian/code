    public class HWSysManagerImpl : IHWSysManager
    {
        private HWSysManager _hwSysManager; //Initialize from constructor
        public int OpenConfiguration(string hwPath)
        {
            return _hwSysManager.openConfiguration(hwPath);
        }
    }
