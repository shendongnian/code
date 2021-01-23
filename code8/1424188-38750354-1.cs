    class B
    {
        public Prop {get; set;}
    }
    public static void PrintPropertyName<T>(Expression<Func<T>> expression)
        {
            var member = (MemberExpression)expression.Body;
            Console.WriteLine(member.Member.Name);
        }
       public static void PrintPropertyName2<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            Console.WriteLine(body.Member.Name); 
        }
