    public static IEnumerable<string> Get<T>(Expression<Func<T, object>> selector)
    {
        var list = new List<string>();
        Expression exp = (selector.Body as UnaryExpression).Operand as MethodCallExpression;
        while (exp is MethodCallExpression)
        {
            var call = exp as MethodCallExpression;
            var arg = call.Arguments[0].ToString();
            if(call.Arguments[0].Type == typeof(string))
            {
                arg = arg.Substring(1, arg.Length - 2);
            }
            list.Add(arg);
            exp = call.Object as Expression;
        }
 
        var member = exp as MemberExpression;
        list.Add(member.Member.Name);
          
        list.Reverse();
        return list;
    }
    static void Main(string[] args)
    {
        var graph = Get<SomeObject>(o => o.Entries["first"]["b"]);
        foreach (var node in graph)
        {
            Console.WriteLine(node);
        }            
        Console.ReadLine();
    }
