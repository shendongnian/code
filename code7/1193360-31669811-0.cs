    public abstract class BaseClass
    {
        protected abstract void MethodThatMustBeDefinedInSubClasses();
    }
    public class ChildClass : BaseClass
    {
        protected override void MethodThatMustBeDefinedInSubClasses()
        {
            Console.WriteLine("Do");
        }
    }
    public static class BaseClassExtensions
    {
        public static void DoExtension(this BaseClass foo) { }
        public static void DoExtension(this ChildClass bar) {}
    }
