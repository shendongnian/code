        private static void Main(string[] args)
        {
            var maxLength = GetMaxLengthAttributeValue<Transaction>("R03Place");
            Console.WriteLine("R03Place = {0}",maxLength);
            maxLength = GetMaxLengthAttributeValue<Transaction>("R03Code");
            Console.WriteLine("R03Place = {0}",maxLength);
            Console.ReadLine();
        }
        public static int? GetMaxLengthAttributeValue<T>(string propertyName)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            var found = props.Where(m => m.Name.Equals(propertyName));
            if (found.Any())
            {
                var propertyInfo = found.First();
                var attrs = propertyInfo.GetCustomAttributes(false);
                
                foreach (object attr in attrs)
                {
                    MaxLengthAttribute maxLengthAttribute = attr as MaxLengthAttribute;
                    if (maxLengthAttribute != null)
                    {
                        return maxLengthAttribute.Length;
                    }
                }
            }
  
            return null;
        }
