    public class Base
    {
        private Lazy<List<string>> l =  new Lazy<List<string>>(() => RunStatic());
        private static List<string> RunStatic()
        {
            //
        }
        public List<string> ResultOfRun
        {
            get
            {
                 return l.Value();
            }
        }
        void methodA();
    }
