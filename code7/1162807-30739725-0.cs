    public class AuditingService: IEnlistmentNotification
    {
        private bool _isCommitSucceed = false;
        public AuditingService()
        {
            //init your audit
            Transaction.Current.EnlistVolatile(this, EnlistmentOptions.None);
        }
        public void Commit(Enlistment enlistment)
        {
            //create audit record
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
