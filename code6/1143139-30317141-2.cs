    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace NSSimulation
    {
        public interface ISimulation
        {
            int runSimulation();
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class Simulation : ISimulation
        {
            [ComVisible(true)]
            public int runSimulation()
            {
                return 0;
            }
        }
    }
