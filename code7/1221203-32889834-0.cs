    using System;
    using System.Collections.Generic;
    //more usings...
    
    namespace MyNamespace
    {
        public class HostDllB1
        {
            private Dictionary<string, string> Parameters = new Dictionary<string, string>();
    
            public HostDllB1()
            {
            }
    
            public int SetParam(string name, string value)
            {
                Parameters[name] = value;
                return 1;
            }
    	}
    }
