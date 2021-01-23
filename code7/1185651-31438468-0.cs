    public abstract class BaseClass
    {
        public abstract void DoFoo();
    }
    public class ClassNumber001 : BaseClass
    {
        public override void DoFoo()
        {
            Console.WriteLine("001 Foo");
        }
    }
    public class ClassNumber002 : BaseClass
    {
        public override void DoFoo()
        {
            Console.WriteLine("002 Foo");
        }
    }
    public interface ISuperman
    {
        void Do();
    }
    public class Superman<T> : ISuperman where T : BaseClass
    {
        private T baseClass;
        public Superman(T baseClass)
        {
            this.baseClass = baseClass;
        }
        public void Do()
        {
            this.baseClass.DoFoo();
        }
    }
    public class MainViewModel
    {
        public MainViewModel(IEnumerable<ISuperman> lotsofSuperman)
        {
            foreach(ISuperman superman in lotsofSuperman)
            {
                superman.Do();
            }
        }
    }
