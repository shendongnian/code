     class Program
        {
            static void Main(string[] args)
            {
                List<IGameState> lstSaveState = new List<IGameState>();
                // For Saving State
                lstSaveState.ForEach(x=>x.SaveState());
            // For Reading State
            lstSaveState.ForEach(x => x.ReadState());
        }
    }
    public interface IGameState
    {
        void SaveState();
        IGameState ReadState();
    }
    public class DirectorySettings : IGameState
    {
        public void SaveState()
        {
            // Serialize
        }
        public IGameState ReadState()
        {
            // Deserialize
            throw NotImplementedException();
        }
    }
    public class LoopSettings : IGameState
    {
        public void SaveState()
        {
            // Serialize
        }
        public IGameState ReadState()
        {
            // Deserialize
            throw NotImplementedException();
        }
    }
