    using VisualStimulation.Utilities;
    using Xamarin.Forms;
    
    namespace VisualStimulation.Effects
    {
        public class SwitchEffects : RoutingEffect
        {
            public SwitchEffects() : base($"{Constants.ResolutionGroupName}.{nameof(SwitchEffects)}")
            {
            }
        }
    }
