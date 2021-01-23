    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    static void Example<T>(Expression<Func<T, object>> identifierExpression)
    {
        MemberExpression prop = identifierExpression.Body as MemberExpression;
        Console.WriteLine(prop.Member);
    }
    static void Main(string[] args)
    {
        var person = new Person { FirstName = "jd", LastName = "phenix" };
        Example<Person>(x => x.FirstName);
    }
