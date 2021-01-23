    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public class PerfLibTest
        {
    #if DEBUG
            private DateTime dtStarted;
    #endif
    
            public void StartIt()
            {
    #if DEBUG
                dtStarted = DateTime.Now;
    #endif
            }
    
            public void StopAndLogIt()
            {
    #if DEBUG
                //write somewhere (DateTime.Now-dtStarted).TotalMilliseconds
    #endif
            }
    
        }
    }
