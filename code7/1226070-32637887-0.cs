        static void Main(string[] args)
        {
            ObjectGenerateNullValues(new Contact(), "contact");
        }
        private static void ObjectGenerateNullValues(object objectType, string objectName)
        {
            var props = objectType.GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(@"c:\temp\ObjectPropertiesOutput.txt", true))
            {
                foreach (var p in props)
                {
                    sw.WriteLine("{0}.{1} = null", objectName, p.Name);
                }
            }
        }
