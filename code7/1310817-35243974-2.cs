    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace LibraryA
    {
        public class RealClass
        {
            public int DoIt()
            {
                LibraryB.ReferencedClass cl = new LibraryB.ReferencedClass();
                return cl.GetIt();
        
            }
        }
    }
