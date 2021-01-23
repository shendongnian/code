    public class cA<T>
    {
        private IEnumerable<T> _myPrivateData
        
        public bool Find(args)
        {
            // Do stuff with _myPrivateData
        }
    }
    public class cB : cA<TheTypeIWant>
    {
        // more stuff here if needed
    }
