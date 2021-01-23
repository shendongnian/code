    public class FileMover : IEnlistmentNotification
    {
        private readonly string _source;
        private readonly string _destination;
        public FileMover(string source, string destination)
        {
            Transaction.Current.EnlistVolatile(this, EnlistmentOptions.None);
            _source = source;
            _destination = destination;
            File.Move(_source, _destination);
        }
        public void Commit(Enlistment enlistment)
        {
            enlistment.Done();
        }
        public void InDoubt(Enlistment enlistment)
        {
            enlistment.Done();
        }
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
        }
        public void Rollback(Enlistment enlistment)
        {
            File.Move(_destination, _source);
            enlistment.Done();
        }
    } 
