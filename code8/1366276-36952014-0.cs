    public class CSharpWrapper
    {
        // Create delegate type
        public delegate void TestDelegate();
        // Connection with the native side
        [DllImport("__Internal")]
        private static extern void externMethod( TestDelegate onCompletion);
     
        private static Action callback = null;
     
        // This is most likely the part you are looking for.
        // That method is marshalled so it will pass its address to the native side
        // When native calls it we can add any code within  
        [MonoPInvokeCallback(typeof(TestDelegate))]
        private static void ManagedTest()
        {
            if(callback != null) { callback(); }
            callback = null;
        }
        #endif
     
        public static void CallMethod(Action<string> onCompletion)
        {
            callback = onCompletion;
            // Here we pass our own method that is marshalled for native side
            externMethod(ManagedTest);
        }
    }
