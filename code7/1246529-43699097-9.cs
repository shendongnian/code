        using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Web;
    
    namespace YOUR_SOLUTION_NAME.Models.CustomValidation
    {
        public class ValidImageFileAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;
    
                string[] _validExtensions = { "JPG", "JPEG", "BMP", "GIF", "PNG" };
    
                var file = (HttpPostedFileBase)value;
                var ext = Path.GetExtension(file.FileName).ToUpper().Replace(".", "");
                return _validExtensions.Contains(ext) && file.ContentType.Contains("image");
            }
        }
    }
