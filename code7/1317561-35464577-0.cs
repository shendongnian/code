    private struct <M>d__0 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncTaskMethodBuilder <>t__builder;
        void IAsyncStateMachine.MoveNext()
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.<>1__state = -2;
                this.<>t__builder.SetException(exception);
                return;
            }
            this.<>1__state = -2;
            this.<>t__builder.SetResult();
        }
        [DebuggerHidden]
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            this.<>t__builder.SetStateMachine(stateMachine);
        }
    }
