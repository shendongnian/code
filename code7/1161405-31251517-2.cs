    [ContentProperty("Items")]
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            //the Children property seems to be lazy-loaded so we need to
            //call the getter to invoke CreateUIElementCollection
            Children.ToString();
        }
        private readonly Panel InnerPanel = new DockPanel();
        public UIElementCollection Items { get { return InnerPanel.Children; } }
        protected override Size ArrangeOverride(Size finalSize)
        {
            InnerPanel.Arrange(new Rect(new Point(0, 0), finalSize));
            return finalSize;
        }
        protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
        {
            return new ChildCollection(this);
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            InnerPanel.Measure(availableSize);
            return InnerPanel.DesiredSize;
        }
        private sealed class ChildCollection : UIElementCollection
        {
            public ChildCollection(CustomPanel owner)
                : base(owner, owner)
            {
                //call the base method (not the override) to add the inner panel
                base.Add(owner.InnerPanel);
            }
            public override int Add(UIElement element) { throw new NotSupportedException(); }
            public override void Clear() { throw new NotSupportedException(); }
            public override void Insert(int index, UIElement element) { throw new NotSupportedException(); }
            public override void Remove(UIElement element) { throw new NotSupportedException(); }
            public override void RemoveAt(int index) { throw new NotSupportedException(); }
            public override void RemoveRange(int index, int count) { throw new NotSupportedException(); }
            public override UIElement this[int index]
            {
                get { return base[index]; }
                set { throw new NotSupportedException(); }
            }
        }
    }
