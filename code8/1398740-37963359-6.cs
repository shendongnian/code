    public class SomeTopClass
    {
       
        // ...
        
        public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
        {
            // ...
        }
        
        // class is in SomeClass, therefore it is a nested class. You cannot define extension mathods here
        public static class ExtensionMethods
        {
            public static string ToFileSize(this long l)
            {
                return String.Format(new FileSizeFormatProvider(), "{0:fs}", l);
            }
        }
    }
