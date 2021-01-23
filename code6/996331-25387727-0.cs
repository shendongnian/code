    public class MyLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged (
             ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged (e);
            MyLabel el = (MyLabel)this.Element;
            // custom stuff here
        }
    }
