    public class SampleOutput
    {
        public void SomeMethod(string arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("arg");
            }
        }
        
        public void AnotherMethod(string arg)
        {
        }
        
        public string MethodAllowsNullReturnValue()
        {
            return null;
        }
    }
