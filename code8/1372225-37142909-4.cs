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
                ContextMenuOpening += (s, e) => ContextMenu.DataContext = this;
            }
            public static readonly DependencyProperty ArbitraryPropertyProperty =
                DependencyProperty.Register("ArbitraryProperty", typeof(String), typeof(Bar),
                    new PropertyMetadata(nameof(Bar)));
        }
    }
