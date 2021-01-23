    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace YourWebApp.Models
    {
        [MetadataType(typeof(YourClassMetaData))]
        public partial class YourClass
        {
            [DisplayName("Year Obtained")]
            public int YYObtained {
                get
                {
                    return this.reDateFrom.Year;
                }
            }
        }
    
        public class YourClassMetaData
        {
            [DataType(DataType.Date)]
            public DateTime reDateFrom { get; set; }
        }
    }
