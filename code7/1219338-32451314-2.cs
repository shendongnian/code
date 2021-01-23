    public interface IProcessStrategy
    {
        void Process();
    }
    public class BaseClass
    {
        private IProcessStrategy _strategy;
   
        public void Process()
        {
            // this is where the real "override" happens
            if ( _strategy == null )
            {
                // default implementation
                ...
            }
            else
                // overridden
                _strategy.Process();
        }
        public void OverrideWith( IProcessStrategy strategy )
        {
            this._strategy = strategy;
        }
