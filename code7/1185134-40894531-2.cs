      public class DGFeature
    {
        public string FeatureName { get; set; }
        public bool FeatureExists { get; set; }
        public List<LibTrackingSystem.Machine> FeatureMachines { get; set; }
        public LibTrackingSystem.Machine SelectedMchn { get; set; }
        public DGFeature()
        {
            FeatureMachines = new List<LibTrackingSystem.Machine>();
            SelectedMchn = new LibTrackingSystem.Machine();
        }
    }
