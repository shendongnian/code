    class MyClass
    {
        string[] Country ;
        string[] Province;
        string[] City ;
        
       public static From_Byte(MyByteClass  mbc)
       {
          return new MyClass {
            Country = mbc.Country.ASCII_string() ),
            Province = mbc.Province.ASCII_string() ),
            City = mbc.City.ASCII_string() ),
          };
       }  
     }
  
    class MyByteClass
    {
        byte[] Country ;
        byte[] Province;
        byte[] City ;
     }
    
    public static class AsciiExt
    {
        public static byte[] ASCII_bytes(this string str)
        {
            return str == null ?
             new byte[0] : Encoding.ASCII.GetBytes(str);
        }
        public static string ASCII_String(this byte[] byteArr)
        {
            return byteArr == null ?
             string.Empty :
             Encoding.ASCII.GetString(byteArr);
        }
    }
    
    
    public class byteArrayInterningObject
    {
        private Dictionary<byte[], byte[]> _items;
    
        public byteArrayInterningObject()
        {
            _items = new Dictionary<byte[], byte[]>();
        }
    
        public string Add(byte[] value)
        {
            string result;
            if (!_items.TryGetValue(value, out result))
            {
                _items.Add(value, value);
                return value;
            }
            return result;
        }
    }
