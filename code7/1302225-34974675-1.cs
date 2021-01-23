    using Newtonsoft.Json.Linq;
    using System;
    
    namespace ConsoleApplication1
    {
    
        public static class Arac
        {
            public static int adli_tip { get; set; }
            public static int aile_hukuku { get; set; }
            public static int avrupa_birligi_hukuku { get; set; }
            public static int bankacilik_hukuku { get; set; }
    
    
            public static string string_value {get; set;}
            public static DateTime date_value { get; set; }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"
    {
      ""adli_tip"": 15,
      ""aile_hukuku"": 43,
      ""avrupa_birligi_hukuku"": 22,
      ""bankacilik_hukuku"": 10,
    
    ""string_value"": ""some value"",
    ""date_value"": ""2016-01-24 11:18:00""
    }";
                JObject arac = JObject.Parse(json);
                foreach (var prop in typeof(Arac).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                {
                    var token = arac.GetValue(prop.Name);
                    if (token != null)
                    { 
                        object value = token.ToObject(prop.PropertyType);
                        prop.SetValue(null, value);
                    }
                }
    
                Console.WriteLine("adli_tip {0}", Arac.adli_tip);
                Console.WriteLine("aile_hukuku {0}", Arac.aile_hukuku);
                Console.WriteLine("avrupa_birligi_hukuku {0}", Arac.avrupa_birligi_hukuku);
                Console.WriteLine("bankacilik_hukuku {0}", Arac.bankacilik_hukuku);
                Console.WriteLine("string_value {0}", Arac.string_value);
                Console.WriteLine("date_value {0}", Arac.date_value);
            }
        }
    }
