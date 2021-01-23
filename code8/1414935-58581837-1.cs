    public class SaveDataFlow : ISaveDataFlow
    {
        private readonly IWriter _writers;
        public SaveDataFlow(IEnumerable<IWriter> writers)
        {
            _writers= writers;
        }
        public void SaveData(string data, string outputType)
        {
            _writers.Single(w => w.CanWrite(outputType)).WriteToStorage(data);
        }
    }
