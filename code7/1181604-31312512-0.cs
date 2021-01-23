        public interface IChildAction
        {
        }
        public class ChildAction1 : IChildAction
        {
        }
        public class ChildAction2 : IChildAction
        {
        }
        public class ChildAction3 : IChildAction
        {
        }
        public abstract class BaseRootAction
        {
            public virtual bool Process(ChildAction1 action)
            {
                return false;
            }
            public virtual bool Process(ChildAction2 action)
            {
                return false;
            }
            public virtual bool Process(ChildAction3 action)
            {
                return false;
            }
        }
        public class RootAction1 : BaseRootAction
        {
            public override bool Process(ChildAction1 action)
            {
                Console.WriteLine("Root action 1, Child action 1");
                return true;
            }
            public override bool Process(ChildAction2 action)
            {
                Console.WriteLine("Root action 1, Child action 2");
                return true;
            }
        }
        public class RootAction2 : BaseRootAction
        {
            public override bool Process(ChildAction1 action)
            {
                Console.WriteLine("Root action 2, Child action 1");
                return true;
            }
            public override bool Process(ChildAction3 action)
            {
                Console.WriteLine("Root action 2, Child action 3");
                return true;
            }
        }
        public class RootAction3 : BaseRootAction
        {
            public override bool Process(ChildAction2 action)
            {
                Console.WriteLine("Root action 3, Child action 2");
                return true;
            }
        }
        public bool DoMyThings(BaseRootAction rootAction, IChildAction childAction)
        {
            return rootAction.Process((dynamic)childAction);
        }
