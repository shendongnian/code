    public class SapMaterialFormatter : ISapFunction<string>
    {
        // shortened for brevity
        public void Import(string obj)
        {
             _raw = obj;
        }
        public string Export()
        {
             return _formatted;
        }
        public void Call(RfcRepository repo, RfcDestination dest)
        {
        }
    }
