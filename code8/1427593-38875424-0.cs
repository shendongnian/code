        private class FooEnlistment : IEnlistmentNotification
        {
            private readonly Action _CommitAction;
            private readonly Action _RollbackAction;
            public EventEnlistment(Action onCommit, Action onRollback)
            {
                _CommitAction = onCommit;
                _RollbackAction = onRollback;
            }
            public void Prepare(PreparingEnlistment preparingEnlistment)
            {
                preparingEnlistment.Prepared();
            }
            public void Commit(Enlistment enlistment)
            {
                _CommitAction();
                enlistment.Done();
            }
            public void Rollback(Enlistment enlistment)
            {
                _RollbackAction();
                enlistment.Done();
            }
            public void InDoubt(Enlistment enlistment)
            {
                enlistment.Done();
            }
        }
