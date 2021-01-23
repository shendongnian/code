    public class ViewModel
    {
        public virtual void DoMethod()
        {
            DoAnotherMethod();
        }
        public void DoAnotherMethod() {...}
    }
    public class ThisName: ViewModel
    {
        public override void DoMethod()
        {
            DoThisMethod();
        }
        public void DoThisMethod() {...}
    }
