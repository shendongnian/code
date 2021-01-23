    namespace ConsoleApplication
    {
        public class Kitten : ISimpleClone<Kitten>
        {
            public string Name { get; set; }
            public string FurColour { get; set; }
    
            public int? Number { get; set; }
    
            public Kitten SimpleClone()
            {
                return new Kitten { Name = this.Name, FurColour = this.FurColour, Number = this.Number };
            }
        }
    
        public interface ISimpleClone<T>
        {
            T SimpleClone();
        }
    
        public class Program
        {
            public static PropertyInfo GetProperty<TObject, TProperty>(Expression<Func<TObject, TProperty>> propertyExpression)
            {
                MemberExpression body = propertyExpression.Body as MemberExpression;
                if (body == null)
                {
                    var unaryExp = propertyExpression.Body as UnaryExpression;
                    if (unaryExp != null)
                    {
                        body = ((UnaryExpression)unaryExp).Operand as MemberExpression;
                    }
                }
    
                return body.Member as PropertyInfo;
            }
    
            public static T Nullify<T>(T item, params Expression<Func<T, object>>[] properties)
                where T : ISimpleClone<T>
            {
                // Creates a new instance
                var newInstance = item.SimpleClone();
    
                // Gets the properties that will be null
                var propToNull = properties.Select(z => GetProperty<T, object>(z));
                var filteredProp = propToNull
                    .Where(z => !z.PropertyType.IsValueType || Nullable.GetUnderlyingType(z.PropertyType) != null) // Can be null
                    .Where(z => z.GetSetMethod(false) != null && z.CanWrite); // Can be set
                foreach (var prop in filteredProp)
                {
                    prop.SetValue(newInstance, null);
                }
    
                return newInstance;
            }
    
            public static void Main(string[] args)
            {
                var kitten = new Kitten() { Name = "Mr Fluffykins", FurColour = "Brown", Number = 12 };
    
                var anonymousKitten = Nullify(kitten, c => c.Name, c => c.Number);
    
                Console.Read();
            }
        }
    }
