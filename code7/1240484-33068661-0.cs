    public class Laa<T>
    where T : FrameworkElement
    {
        public Laa(T element)
        {
        }
        public Foo(T element)
        {
        }
    }
    var x = new Laa<Button>(button);
    x.Foo(button);
