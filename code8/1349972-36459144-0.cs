        public class BaseClassWrapper : BaseClass
        {
            private IBaseMethodA methodA;
            private IBaseMethodB methodB;
            public BaseClassWrapper(IBaseMethodA methodA, IBaseMethodB methodB)
            {
                this.methodA = methodA;
                this.methodB = methodB;
            }
            public override void BaseMethod()
            {
                methodB.BaseMethod();
            }
            public override void BaseMethod(object obj)
            {
                methodA.BaseMethod(obj);
            }
            public interface IBaseMethodA
            {
                void BaseMethod(object obj);
            }
            public interface IBaseMethodB
            {
                void BaseMethod();
            }
        }
