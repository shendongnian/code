    public class SomeTopClass
    {
       
        // ...
        
        public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
        {
            // ...
        }           
    }
    // now you can, because it is not nested inside some other class
    public static class ExtensionMethods
    {
        public static string ToFileSize(this long l)
        {
            return String.Format(new FileSizeFormatProvider(), "{0:fs}", l);
        }
    }
