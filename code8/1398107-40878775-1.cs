	using UIKit;
	using CustomEntrySample;
	using CustomEntrySample.iOS;
	using Xamarin.Forms;
	using Xamarin.Forms.Platform.iOS;
	[assembly: ExportRenderer(typeof(EntryWithTopPadding), typeof(EntryWithTopPaddingCustomRenderer))]
	namespace CustomEntrySample.iOS
	{
		public class EntryWithTopPaddingCustomRenderer : EntryRenderer
		{
			protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
			{
				base.OnElementChanged(e);
                
                if(Control == null)
                    return;
				Control.VerticalAlignment = UIControlContentVerticalAlignment.Bottom;
			}
		}
	}
