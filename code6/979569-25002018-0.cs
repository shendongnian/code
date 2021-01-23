    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using G.E.D.E.RE;
    
    namespace G.E.RE
    {
        public List<DiagnosisCode> DC { get; set; }
    
        public class DC
        {
            public string Code { get; set; }
            public int ICDVersion { get; set; }
        }
    }
