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
var o = new A(0, 0);
var o1 = o.With(x => x.y, 5);
  [1]: https://github.com/kofifus/With
