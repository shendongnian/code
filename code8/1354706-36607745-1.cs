    //https://msdn.microsoft.com/en-us/library/system.icustomformatter(v=vs.110).aspx
    public class NullFormatter:ICustomFormatter, IFormatProvider
    {
        // IFormatProvider.GetFormat implementation.
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested.
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }   
        
         // all formatting visits ths
        public string Format(String fmt, object obj, IFormatProvider fp)
        {
          // do we have our special format?
          if (fmt!= null && fmt.StartsWith("NULL:"))
          {
             // if null do an empty string
             if (obj == null) {
               return String.Empty;
             } else
             {
                // use the part after the NULL: as a formatstring
                return String.Format(fmt.Substring(5), obj);
             }
          }
          else
          {
            // no, do normal handling
            if (obj is IFormattable) {
                obj.Dump();
                return ((IFormattable) obj).ToString(fmt, CultureInfo.CurrentCulture); 
            } else 
            {
                if (obj != null) {
                   return obj.ToString();
                } else
                {
                   return String.Empty;
                }
            }
          }
          return "?";
        }
    }
