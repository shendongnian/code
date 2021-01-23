    namespace SomeNameSpace.ToTest {
        static class RemoteCaller {
            static public string Run() {
                return CallerStuff.FindCallingNameSpace();
            }
        }
    }
