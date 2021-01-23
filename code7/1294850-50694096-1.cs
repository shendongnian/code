    using System.ComponentModel;
    using xamarin.Mobile.IOS;
    using Foundation;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    [assembly: ExportRenderer(typeof(xamarin.Mobile.Controls.HyperlinkButton), typeof(HyperlinkButtonRenderer))]
    namespace xamarin.Mobile.IOS
    {
        public class HyperlinkButtonRenderer : ButtonRenderer
        {
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (Control != null)
                {
                    //Set attribute for underlineing information links
                    var underlineAttr = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.Single };
                    Control.SetAttributedTitle(new NSAttributedString(Control.CurrentTitle, underlineAttr), UIControlState.Normal);
                }
            }
        }
    }
