    public class Laa<T>
    where T : FrameworkElement
    {
        public Laa(T element)
        {
        }
        public void Foo<U>(U element)
        {
        }
    }
    var x = new Laa<Button>(button);
    x.Foo(button);
