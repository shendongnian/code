    class Program {
            static void Main(string[] args) {
                // The sample properties.
                var notTrimmedString = "  smth   ";
                var trimmedString = notTrimmedString.Trim();
    
                // Prepare an object to trim its properties.
                var obj = new A {
                    PropertyToBeTrimmed = notTrimmedString,
                    PropertyNotToBeTrimmed = notTrimmedString,
                };
    
                // Trim properties marked by TrimAttribute.
                foreach(var property in obj.GetType().GetProperties().Where(x => 
                    x.PropertyType == typeof(string) &&
                    x.GetCustomAttributes(typeof(TrimAttribute), true).Any())) {
                    property.SetValue(obj, (property.GetValue(obj) as string).Trim());
                }
    
                // Check.
                Console.WriteLine(obj.PropertyToBeTrimmed == notTrimmedString);
                Console.WriteLine(obj.PropertyNotToBeTrimmed == notTrimmedString);
                Console.WriteLine(obj.PropertyToBeTrimmed == trimmedString);
                Console.WriteLine(obj.PropertyNotToBeTrimmed == trimmedString);
                Console.ReadKey();
            }
        }
    
        /// <summary>
        /// Sample class.
        /// </summary>
        class A {
            /// <summary>
            /// This property must be marked by TrimAttribute. 
            /// So it will be trimmed.
            /// </summary>
            [Trim]
            public string PropertyToBeTrimmed { get; set; }
    
            /// <summary>
            /// This property must be not marked by TrimAttribute. 
            /// So it will not be trimmed.
            /// </summary>
            public string PropertyNotToBeTrimmed { get; set; }
        }
    
        /// <summary>
        /// Custom attribute which means need for trimming.
        /// </summary>
        class TrimAttribute : Attribute { }
