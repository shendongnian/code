    [assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer))]
	namespace XamFormsConnect.Droid
	{
	    public class CustomEntryRenderer : EntryRenderer
	    {
			protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
			{
				base.OnElementChanged(e);
				if (Control != null)
				{
	                var entry = (Xamarin.Forms.Entry)e.NewElement;
					Control.Background.Mutate().SetColorFilter(entry.TextColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
				}
			}
			protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				base.OnElementPropertyChanged(sender, e);
	            if (e.PropertyName == "TextColor") {
					var entry = (Xamarin.Forms.Entry)sender;
					Control.Background.Mutate().SetColorFilter(entry.TextColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
				}
			}
		}
	}
