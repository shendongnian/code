    public class SomeOtherClass
    {
        public void main()
        {
            var vm1 = new ViewModel1();
            var vm2 = new ViewModel2();
            vm1.ChangeValueAction = new Action(() => { vm2.SomeProperty = String.Empty; });
        }
    }
    public class ViewModel1
    {
        public Action ChangeValueAction { get; set; }
        public void SomeMethod()
        {
            ChangeValueAction.Invoke();
        }
    }
    public class ViewModel2
    {
        public string SomeProperty { get; set; }
    }
