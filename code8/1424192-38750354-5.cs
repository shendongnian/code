    public static string GetName<T>(Expression<Func<T>> expression)
        {
            var member = (MemberExpression)expression.Body;
            return member.Member.Name;
        }
        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            return body.Member.Name;
        }
        public static void PrintName<T>(Expression<Func<T>> expression)
        { 
            Console.WriteLine(GetName(expression));
        }
        public static void PrintName<T>(Expression<Func<T, object>> expression)
        { 
            Console.WriteLine(GetName(expression));
        }
