The big issue with this code is that you are trying to get the Min() value, but with a list of objects that don't implement IComparable.
In this case, you can implement IComparable interface on Set class or get the Min choosing what property should be returned:
namespace S
{
    public sealed class C
    {
    public class Set
    {
        public DateTime time { get; set; }
        public Decimal x { get; set; }
        public Decimal y { get; set; }
    }
    public static Dictionary<String, List<Set>> _SET;
    public static void MyFunction()
    {
        Int32 _h = 1, _period = 30;
        Decimal _my_decimal = (_SET[" my key "].Skip(_h * _period).Take(_period).Min(y => y.x);
    }
}
