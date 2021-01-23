    public class MyScrollViewer : ScrollViewer
    {
        static MyScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyScrollViewer), new FrameworkPropertyMetadata(typeof(MyScrollViewer)));
        }
        
    }
