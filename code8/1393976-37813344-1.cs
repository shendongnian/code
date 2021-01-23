    public class DelegateUpdateAction : IUpdateAction
    {
        private Func<bool> _updateAction;
        private Func<bool> _shouldUpdateCheck;
        public DelegateUpdateAction(Action action, bool isLastAction = false, Func<bool> shouldUpdateCheck = null)
            : this(() =>
            {
                action();
                return isLastAction;
            },
            shouldUpdateCheck)
        { }
        public DelegateUpdateAction(Func<bool> updateAction, Func<bool> shouldUpdateCheck = null)
        {
            if(updateAction == null)
            {
                throw new ArgumentNullException("updateAction");
            }
            _updateAction = updateAction;
            _shouldUpdateCheck = shouldUpdateCheck ?? (() => true); 
        }
        public bool ShouldUpdate()
        {
            return _shouldUpdateCheck();
        }
        public bool Update()
        {
            return _updateAction();
        }
    }
