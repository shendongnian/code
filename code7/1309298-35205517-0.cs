    using System.Linq.Expressions;    
    
    string name = GetName(() => Properties.Resources.Key1);
    static string GetName<T>(Expression<Func<T>> property)
    {
        return (property.Body as MemberExpression).Member.Name;
    }
