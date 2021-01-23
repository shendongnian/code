    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Android.Graphics;
    
        [assembly: ExportRenderer(typeof(Entry), typeof(some.namespace.EntryRenderer))]
        namespace some.namespace
        {
            public class EntryRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
            {
                protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
                {
                    base.OnElementChanged(e);
                    if (Control == null || Element == null || e.OldElement != null) return;
        
                    var customColor = Xamarin.Forms.Color.FromHex("#0F9D58");
                    Control.Background.SetColorFilter(customColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                }
            }
        }
