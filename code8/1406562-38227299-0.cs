    [assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
    namespace MyRenderers
    {
        public class MyEntryRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
    
                if (Control == null || e.NewElement == null) return;
    
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(Color.White);
                else
                    Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
             }    
        }
    }
