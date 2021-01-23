    public class Laa<T>
    where T : FrameworkElement
    {
        public Laa(T element)
        {
        }
        public void Foo(T element)
        {
        }
    }
    var x = new Laa<Button>(button);
    x.Foo(button);
