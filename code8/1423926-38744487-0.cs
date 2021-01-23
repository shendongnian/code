    public interface ISomeInterface {}
    public class Child: ISomeInterface {}
    public class OtherChild : ISomeInterface { }
    public static class MyInterfaceExtensions
    {
        public static MyObj<T> GetMyObj<T>(this T child) where T : ISomeInterface
        {
            return new MyObj<T>();
        }
    }
    public static class Test
    {
        public static void RunTest()
        {
            var child = new Child();
            var otherChild = new OtherChild();
            MyObj<Child> myObj = child.GetMyObj();
            MyObj<OtherChild> myOtherObj = otherChild.GetMyObj();
        }
    }
