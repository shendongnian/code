    public class Actor
    {
        private IEnumerable<IUpdateAction> _updateActions;
        public Actor(){
            _updateActions = new List<IUpdateAction>{
                new DelegateUpdateAction((Action)UpdateMovement),
                new DelegateUpdateAction((()=>{ }), true, () => IsIncapacitated),
                new DelegateUpdateAction((Action)UpdateInventory, true, () => IsInventoryOpened),
                new DelegateUpdateAction((Action)Fire, true, () => Input.HasAction(Actions.Fire)),
                new DelegateUpdateAction(() => Move(Input.Axis), true, () => Input.HasAction(Actions.Move))
            };
        }
        private Input Input { get; set; }
        public void Update()
        {
            foreach(var action in _updateActions)
            {
                if (action.ShouldUpdate())
                {
                    if (action.Update())
                        break;
                }
            }
        }
        #region Actions
        private bool IsIncapacitated { get; set; }
        private bool IsInventoryOpened { get; set; }
        private void UpdateMovement()
        {
        }
        private void UpdateInventory()
        {
        }
        private void Fire()
        {
        }
        private void Move(string axis)
        {
        }
        #endregion
    }
