    public class MyObject
    {
        public bool SomeBool {get; set;}
        public string SomeString {get; set;}
        public double SomeDouble {get; set;}
        public float SomeFloat {get; set;}
        public int SomeInt {get; set;}
        public System.Diagnostics.Stopwatch Stopwatch {get; set;}
        
        public MyObject()
        {
            this.Stopwatch = System.Diagnostics.Stopwatch.StartNew();
        }
    }
