    public class SapMaterialFormatter : ISapFunction
    {
        // shortened for brevity
        public void Import<T>(T obj)
        {
             _raw = obj;
        }
        public T Export<T>()
        {
             return _formatted;
        }
        public void Call(RfcRepository repo, RfcDestination dest)
        {
        }
    }
