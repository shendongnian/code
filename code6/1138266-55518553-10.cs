    							   |  reduction  |
	|                     | ram mb |  mb  |  %   |                  |
	|---------------------|--------|------|------|------------------|
	| string              | 680    |      |      |                  |
	| string.intern       | 513    | 167  | 25   |                  |
	| byte[]              | 486    | 194  | 29   | hard to maintain |
	| byte[].CustomIntern | 447    | 233  | 34   | hard to maintain |
also i had to add byteArrayEqualityComparer to byte[].customIntern .
otherwise equals gethashcode doesnt work as expected.
----------
**edit1:**
if ascii ( 256 chars  lating-english alphabet) is okay for you.  
convert  all strings to byte[]. And use byte[] intern . 
but this may create lots of unforeseen problem.
also you may need  get char array and if check if its numeric value bigger than 256. throw exception to be sure. if your alhabet of recordlist is good to go.
From Database to byteClass
    var AllDbResults_2mRec = new List<MyByteClass>();
    foreach (var fields in DbRowProvider)
       AllDbResults_2mRec.Add(
       new MyClass {
            Country = byteArrayInterningObject.Intern(fields[0].ASCII_bytes() ),
            Province = byteArrayInterningObject.Intern(fields[1].ASCII_bytes() ),
            City = byteArrayInterningObject.Intern(fields[2].ASCII_bytes() ),
          } );
when you search 2Million MyByteClass  record.  
you filtered down to  20 record ( for example)
     
    MyByteClass[] results_asByte =  AllDbResults_2mRec .Search("tokyo");
    
    MyClass[] results = results_asByte
                        .Select(x=> MyClass.From_Byte(x) )
                        .ToArray();   
Required Classes
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
   
