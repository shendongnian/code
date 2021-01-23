    namespace artisan.Attributes
    {
    	public class FileSizeAttribute : ValidationAttribute
    	{
    		private readonly int _maxSize;
    
    		public FileSizeAttribute(int maxSize)
    		{
    			_maxSize = maxSize;
    		}
    
    		public override bool IsValid(object value)
    		{
    			if (value == null) return true;
    
    			return _maxSize > (value as HttpPostedFile).ContentLength;
    		}
    		public override string FormatErrorMessage(string name)
    		{
    			return string.Format("The image size should not exceed {0}", _maxSize);
    		}
    	}
    
    	public class FileTypesAttribute : ValidateInputAttribute
    	{
    		private readonly List<string> _types;
    
    		public FileTypesAttribute(string types)
    		{
    			_types = types.Split(',').ToList();
    		}
    
    		public override bool IsValid(object value)
    		{
    			if (value == null) return true;
    
    			var fileExt = System.IO.Path.GetExtension((value as HttpPostedFile).FileName).Substring(1);
    			return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
    		}
    
    		public override string FormatErrorMessage(string name)
    		{
    			return string.Format("Invalid file type. Only the following types {0} are supported.",
    				String.Join(", ", _types));
    		}
    	}
    }
