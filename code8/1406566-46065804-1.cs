	[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer))]
	namespace XamFormsConnect.Droid
	{
	    public class CustomEntryRenderer : EntryRenderer
	    {
			protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
			{
				base.OnElementChanged(e);
				if (Control != null && e.NewElement != null)
				{
	                var entry = (Xamarin.Forms.Entry)e.NewElement;
					if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
						Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
					else
						Control.Background.SetColorFilter(entry.TextColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
				}
			}
		}
	}
