    public class MyClass
    {
        private Object lockObj = new Object();
        public Int32 value1 { get; set;}
        public String value2 { get; set;}
        public string WriteResult2()
        {
            lock (this.lockObj)
            {
                 return "Result: value=" + this.value1 + " name=" + this.value2 ;
            }
        }
    } 
