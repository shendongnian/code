    class Program
        {
            static void Main(string[] args)
            {
                var s = CodeMapping.Code1;
            }
    
            public static class CodeMapping
            {
                private static readonly string _code1;
                private static readonly string _code2;
    
                 static CodeMapping()
                 {
                     string filePath = "code file path";
                     var doc = XElement.Load(filePath);
                     _code1 = doc.Elements().SingleOrDefault(r => r.Element("key").Value == "code_name_1").Element("value").Value;
                     _code2 = doc.Elements().SingleOrDefault(r => r.Element("key").Value == "code_name_2").Element("value").Value;
                 }
    
                 public static string Code1 { get { return _code1; }}
                 public static string Code2 { get { return _code2; } }
            }
        }
