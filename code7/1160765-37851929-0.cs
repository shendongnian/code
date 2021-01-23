    namespace Test
    {
        [JetBrains.Annotations.UsedImplicitly]
        public interface A
        {
            // Method 'DoA' is never used
            void DoA();
        }
    
        public class AImplementator: A
        {
            public void DoA()
            {
                throw new System.NotImplementedException();
            }
        }
    }
