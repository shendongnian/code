    using System;
    using System.Configuration;
    
    namespace WebApplication2
    {
        public class MyConfig : ConfigurationSection
        {
            private static readonly MyConfig ConfigSection = ConfigurationManager.GetSection("MyConfig") as MyConfig;
    
            public static MyConfig Settings
            {
                get
                {
                    return ConfigSection;
                }
            }
    
    
            [ConfigurationProperty("Dept1", IsRequired = true)]
            public string Dept1
            {
                get
                {
                    return (string)this["Dept1"];
                }
    
                set
                {
                    this["Dept1"] = value;
                }
            }
    
            [ConfigurationProperty("Dept2", IsRequired = true, DefaultValue = "abc.def.ghi")]
            public string Dept2
            {
                get
                {
                    return (string)this["Dept2"];
                }
    
                set
                {
                    this["Dept2"] = value;
                }
            }
            // added as example of different types
            [ConfigurationProperty("CheckDate", IsRequired = false, DefaultValue = "7/3/2014 1:00:00 PM")]
            public DateTime CheckDate
            {
                get
                {
                    return (DateTime)this["CheckDate"];
                }
    
                set
                {
                    this["CheckDate"] = value;
                }
            }
        }
    }
