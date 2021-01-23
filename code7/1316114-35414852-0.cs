        public abstract class Foo
        {
            public abstract void Accept(IVisitor visitor);
        }
        public class LocalFoo : Foo
        {
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        public class RemoteFoo : Foo
        {
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        public interface IVisitor
        {
            void Visit(LocalFoo foo);
            void Visit(RemoteFoo foo);
        }
        public class Visitor : IVisitor
        {
            public void Visit(RemoteFoo foo)
            {
                /*Magic Happens Here*/
            }
            public void Visit(LocalFoo foo)
            {
                /*Magic Happens Here*/
            }
        }
