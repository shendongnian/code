    class Program
    {
        static void Main(string[] args)
        {
    
            var propertyInfo = GetPropertyInfo(typeof(A), "PropA.PropC");
            Console.WriteLine(propertyInfo.Name);
            Console.ReadLine();
        }
    
        static PropertyInfo GetPropertyInfo(Type type, string properChain)
        {
            if (!properChain.Contains("."))
            {
                var infos = type.GetProperties().Where(m => m.Name.Equals(properChain));
                return infos.Any() ? infos.First() : null;
            }
    
            var prop = properChain.Split('.')[0];
            var ties = type.GetProperties();
            var found = ties.Where(m => m.Name.Equals(prop));
            return found.Any() ? GetPropertyInfo(found.First().PropertyType, properChain.Replace(prop + ".", "")) : null;
        }
    }
