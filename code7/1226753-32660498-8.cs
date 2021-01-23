    namespace Cssd.IT.PortalIntegration.DataAccess.HR.Dao
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        [MetadataType(typeof(CCS_DEPT_TBL_Meta))]
        public partial class CCS_DEPT_TBL
        {
   
        }
        public class CCS_DEPT_TBL_Meta
        {
            [Key]
            public string DEPTID { get; set; }    
        }
    }
    
