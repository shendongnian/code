sealed class A : IImmutable 
{
    public readonly X x;
    public readonly Y y;
    public class A(X x, Y y)
    {
        this.x = x;
        this.y = y;
    }
}
and you can do:
using System.Immutable;
var a = new A(0, 0);
var a1 = a.With(o => o.y, 5);
  [1]: https://github.com/kofifus/With
