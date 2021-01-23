    public static class Helper
    {
        public static void DoMagic<T>(params Expression<Func<T, object>>[] include) 
        {
            var infos = include.Select(GetPropertyInfo).ToList();
            //do any magic
            foreach (var propertyInfo in infos)
            {
                Console.WriteLine(propertyInfo.Name);
            }
        }
        /// <summary>
        ///     Get PropertyInfo form Expression tree
        /// </summary>
        private static PropertyInfo GetPropertyInfo<TSource, TProperty>(
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof (TSource);
            var expressionCast = propertyLambda.Body as UnaryExpression;
            // this for boxed types
            var expression = propertyLambda.Body as MemberExpression;
            
            if (expressionCast == null && expression == null)
            {
                throw new ArgumentException(string.Format(
                    "Expression '{0}' is not a MemberExpression ",
                    propertyLambda));
            }
            // this for boxed types
            if (expression == null)
            {
                expression = expressionCast.Operand as MemberExpression;
                if (expression == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' is not a MemberExpression",
                        propertyLambda));
                }
            }
            var member = expression.Member;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda));
            var propInfo = member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda));
            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda,
                    type));
            return propInfo;
        }
    }
    public class MyClass
    {
        public int ClientId { get; set; }
        public int PointId { get; set; }
        public string SerialNumber { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Helper.DoMagic<MyClass>(c => c.ClientId, c => c.PointId, c => c.SerialNumber);
            Console.ReadLine();
        }
    }
