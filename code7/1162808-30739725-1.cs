    public class AuditingService: IEnlistmentNotification
    {
        private bool _isCommitSucceed = false;
        private string _record;
        public AuditingService(string record)
        {
            _record = record;
            //init your audit
            Transaction.Current.EnlistVolatile(this, EnlistmentOptions.None);
        }
        public void Commit(Enlistment enlistment)
        {
            //save audit record
            _isCommitSucceed = true;
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
            if (_isCommitSucceed))
            {
                //remove auditing record that was added in commit method
            }
            enlistment.Done();
        }
    }
