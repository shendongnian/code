    namespace SharedContextMenuTest
    {
        public class Foo : Control
        {
            public static readonly DependencyProperty ArbitraryPropertyProperty =
                DependencyProperty.Register("ArbitraryProperty", typeof(String), typeof(Foo),
                    new PropertyMetadata(nameof(Foo)));
        }
        public class Bar : Control
        {
            public Bar()
            {
                //  Foo has an EventSetter in its Style; here we illustrate a quicker way. 
                ContextMenuOpening += (s, e) => ContextMenu.DataContext = this;
            }
            public static readonly DependencyProperty ArbitraryPropertyProperty =
                DependencyProperty.Register("ArbitraryProperty", typeof(String), typeof(Bar),
                    new PropertyMetadata(nameof(Bar)));
        }
    }
