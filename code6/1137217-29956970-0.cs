    public class MyClass : IHasRect
    {
        public Rectangle Rect { get {return m_rect; } } 
        // You need some way to set m_rect, and you
        // will probably have other properties as well.
    }
    QuadTree<MyClass> qt = new QuadTree<MyClass>();
    qd.Insert(new MyClass());
    Rectangle r = qt.First().Rect;
