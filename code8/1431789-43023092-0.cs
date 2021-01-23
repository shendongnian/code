    using UIKit;
    using VisualStimulation.iOS.Effects;
    using VisualStimulation.Utilities;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    [assembly: ResolutionGroupName(Constants.ResolutionGroupName)]
    [assembly: ExportEffect(typeof(SwitchEffects), nameof(SwitchEffects))]
    namespace VisualStimulation.iOS.Effects
    {
        public class SwitchEffects : PlatformEffect
        {
            protected override void OnAttached()
            {
                var switchControl = Control as UISwitch;
                if (switchControl != null)
                {
                    switchControl.OnTintColor = UIColor.FromRGB(204, 153, 255);
                }
            }
            protected override void OnDetached()
            {
    
            }
        }
    }
