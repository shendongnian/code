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
			protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				base.OnElementPropertyChanged(sender, e);
				if (e.PropertyName == "TextColor")
				{
					var entry = (Xamarin.Forms.Entry)sender;
					if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
						Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
					else
						Control.Background.SetColorFilter(entry.TextColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
				}
			}
		}
	}
