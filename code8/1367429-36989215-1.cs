    using System;
    using System.Runtime.CompilerServices;
    namespace Extensions.String
    {
        public static class ConfigWrapper//or some other more appropriate name
        {
            public static string DecryptConfiguration
            {
                get
                {
                    return "5";
                }
            }
    
    
            public static string GetConfig(string configKey);
    
            public static string Encrypt(string str);
        }
    }
