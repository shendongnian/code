        public class ProfileElementList
    {
        public ProfileElementList() { }
        public ObservableCollection<ProfileElement> ProfileElements = new ObservableCollection<ProfileElement>();
        public BezierViewModel BezierCurve { get; set; }
        public BezierViewModel BezierCurveLimit { get; set; }
    }
