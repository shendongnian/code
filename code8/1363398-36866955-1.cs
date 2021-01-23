    public class MainViewModel : ReactiveObject
    {
        private System.Windows.Media.Color _color;
        public System.Windows.Media.Color Color
        {
            get { return _color; }
            set { this.RaiseAndSetIfChanged(ref _color, value); }
        }
    }
