    [ContentProperty("ExpandedContent")]
    public sealed partial class ExpandableListView : UserControl
    {
    ...
        public static readonly DependencyProperty ExpandedContentProperty =
            DependencyProperty.Register(
                "ExpandedContent",
                typeof(Object),
                typeof(ExpandableListView),
                new PropertyMetadata(null));
    ...
        public Object ExpandedContent
        {
            get { return (Object)this.GetValue(ExpandedContentProperty); }
            set { this.SetValue(ExpandedContentProperty, value); }
        }
    
    ...
    }
