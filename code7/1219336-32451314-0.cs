    public interface IProcessStrategy
    {
        void Process();
    }
    public class ProcessService
    {
        public void DoProcess( IProcessStrategy strategy )
        {
            ...whatever
            strategy.Process();
            ...whatever else
        }
    }
