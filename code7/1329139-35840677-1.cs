    namespace OtherAssembly
    {
        public interface IB
        {
            void AddAction(Action act);
        }
        public class A
        {
            public void AddActionTo(IB b)
            {
                Action act = () => { };
                b.AddAction(act);
            }
        }
    }
