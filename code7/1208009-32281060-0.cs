    [assembly: ExportRenderer(typeof(ListView), typeof(MyListViewRenderer))]
    namespace myApp.iOS.Custom_Renderers
    {
        public class MyListViewRenderer : ListViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
            {
                base.OnElementChanged(e);
                var table = (UITableView)this.Control;
                table.SeperatorInset = UIEdgeInsets.Zero;
            }
        }
    }
