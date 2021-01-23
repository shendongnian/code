csharp
if (mock.TargetType.IsInterface) // !!! needs to be true here
{
    // !!! we end up here and proceed to `DefaultValueProvider`
}
else
{
	Debug.Assert(mock.TargetType.IsClass); // !!! needs to pass here
	Debug.Assert(mock.ImplementsInterface(declaringType)); // !!! needs to pass here
	// Case 2: Explicitly implemented interface method of a class proxy.
......
for that we could fulfill two conditions:
1. `mock.TargetType` should be a target class instance type
2. `this.InheritedInterfaces` should contain our interface
the second one is easy enough to build:
csharp
private void AddInheritedInterfaces(T targetInstance)
{
    var moqAssembly = Assembly.Load(nameof(Moq));
    var mockType = moqAssembly.GetType("Moq.Mock`1");
    var concreteType = mockType.MakeGenericType(typeof(T));
    var fi = concreteType.GetField("inheritedInterfaces", BindingFlags.NonPublic | BindingFlags.Static);
    
    var t = targetInstance.GetType()
        .GetInterfaces()
        .ToArray();
    fi.SetValue(null, t);
}
but as far as I'm aware, overriding an expression-bodied property marked `internal` (which `Mock<>.TargetType` is) is impossible without `Reflection.Emit` artillery, where it will likely become infeasible due to amonunt of overriding and subclassing required - you might be better off just forking `Moq` and patching the source code in this case (or submitting a PR maybe?).
###What can be done
It should be possible to generate `Setup` LINQ expressions that automatically call through to your respective instance implementations: 
csharp
//something along these lines, but this is basically sudocode
ISqlUtil sqlUtil = GetTheRealSqlUtilObjectSomehow(...);
var mock = new Mock<ISqlUtil>();
foreach(var methodInfo in typeof(ISqlUtil).GetMembers()) 
{   mock.Setup(Expression.Member(methodInfo)).Returns(Expression.Lambda(Expression.Call(methodInfo)).Compile()())
}
But given how much effort it is to account for everything properly, that again is probably not very feasible.
  [1]: https://stackoverflow.com/a/59664654/12339804
  [2]: https://github.com/moq/moq4/blob/v4.13.1/src/Moq/Interception/InterceptionAspects.cs#L229
  [3]: https://github.com/moq/moq4/blob/master/src/Moq/Interception/InterceptionAspects.cs
