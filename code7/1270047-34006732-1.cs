    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public class CLassToTest
        {
            public void DoSomeJob()
            {
                PerfLibTest pf = new PerfLibTest();
                pf.StartIt();
    
                // do some job
    
                pf.StopAndLogIt();
            }
        }
    }
