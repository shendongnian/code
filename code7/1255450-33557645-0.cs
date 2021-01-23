    namespace Namespace1 {
        namespace Namespace2 {
            public class ClassName {
                public string SomeMethod(int data, out int AnInt) {
                    AnInt = data;
                    return "hello world";
                }
                public string SomeMethod(int data) {
                    int dummy;
                    return SomeMethod(data, out dummy);
                }
            }
        }
    }
