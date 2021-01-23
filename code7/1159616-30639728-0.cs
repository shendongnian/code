    public class AggregatedDateWriter : IDateWriter
    {
        public AggregatedDateWriter(IEnumerable<IDateWriter> writers)
        {
            this._writers = writers; 
        }
        private readonly IEnumerable<IDateWriter> _writers;
        public void WriteDate()
        {
            foreach (IDateWriter writer in this._writers)
            {
                writer.WriteDate();
            }
        }
    }
