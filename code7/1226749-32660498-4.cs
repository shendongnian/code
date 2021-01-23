    namespace Cssd.IT.PortalIntegration.DataAccess.HR.Dao
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
    
        public partial class CCS_DEPT_TBL
        {
            [Key]
            public string PK { get; set; } // This is needed only for Effort
        }
    }
    
