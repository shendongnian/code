    public class MyLongListSelector : LongListSelector
        {
            public ViewportControl ViewportControl { get; private set; }
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                ViewportControl = (ViewportControl)GetTemplateChild("ViewportControl");
            }
        }
