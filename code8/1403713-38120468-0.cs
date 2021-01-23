    public class ParentViewModel
    {
        public ParentViewModel()
        {
            childViewModel = new ChildViewModel(MyAction);
        }
        private void MyAction()
        {
            //i was called by childview model, now do something
        }
        ChildViewModel childViewModel;
    }
    public class ChildViewModel
    {
        private readonly Action action;
        public ChildViewModel(Action action)
        {
            this.action = action;
        }
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                if (something)
                {
                    //call the parent viewmodel
                    action.Invoke();
                }
            }
        }
    }
