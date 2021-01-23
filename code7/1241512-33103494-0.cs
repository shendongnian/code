    public class EventDataPointsViewModel : Mvvm.ViewModel
    {
        private int _phaseAngle;
        public int PhaseAngle
        {
            get { return _phaseAngle; }
            set { SetPropertyAndNotify(ref _phaseAngle, value); }
        }
        private int _amplitude;
        public int Amplitude
        {
            get { return _amplitude; }
            set { SetPropertyAndNotify(ref _amplitude, value); }
        }
        private int _count;
        public int Count
        {
            get { return _count; }
            set { SetPropertyAndNotify(ref _count, value, new[] { "Colour" }); }
        }
        public Brush Colour
        {
            get
            {
                return Count >= 5 ?
                    Brushes.Black :
                    Brushes.Gray;
            }
        }
    }
