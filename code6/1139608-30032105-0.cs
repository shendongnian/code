    public class SomeResource : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new SomeResource();
        }
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(object), typeof(SomeResource), new PropertyMetadata(default(object)));
        public object Context
        {
            get { return (object)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
    }
