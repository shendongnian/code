     public class UsingClass
       {
        private YourClass _yourClass;
        public UsingClass()
        {
           _yourClass = new YourClass();
        }
    
        private void SomeUsingMethod()
        {
           List<string>[] list =  _yourClass.Select();
        }
      }
