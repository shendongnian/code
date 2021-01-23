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
    // guarantee single byte per char. other one return multi byte for single char  like € æ ß  im not sure . but i chnaged it in my production code
    public static byte[] ASCII_Bytes(this string str)
    {      
        if (str == null)
            return new byte[0];
        var byteArr = new byte[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            byteArr[i] = (byte)str[i]; //utf16 - already ascii compliant??
        }
        return byteArr;
    }
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
