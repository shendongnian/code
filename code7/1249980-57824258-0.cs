cs
using System;
using System.Linq.Expressions;
public static class Program {
    public static void Main() {
        Console.WriteLine(Name.Of<A>(x => x.B.Hehe)); // outputs "B.Hehe"
        
        var a = new A();
        Console.WriteLine(Name.Of(() => a.B.Hehe));   // outputs "B.Hehe"
    }
    
    public class A {
    	public B B { get; } // property
    } 
    public class B {
    	public int Hehe; // or field, does not matter
    } 
}
public static class Name 
{
    public static string Of(this Expression<Func<object>> expression) => Of(expression.Body);
    
    public static string Of<T>(this Expression<Func<T, object>> expression) => Of(expression.Body);
    public static string Of(this Expression expression)
    {
        switch (expression)
        {
            case MemberExpression m:                
                var prefix = Of(m.Expression);
                return (prefix == "" ? "" : prefix + ".") + m.Member.Name;
            case UnaryExpression u when u.Operand is MemberExpression m:
                return Of(m);
            default:
                return "";
        }
    }
}
