    [ImplementPropertyChanged]
    public class ApplicationWindowViewModel : ViewModelBase
    {
        public string Title { get; set; }
    
        public double WindowX { get; set; } = 10;
    
        public double WindowY { get; set; } = 10;
    
        public int WindowWidth { get; set; } = 300;
    
        public int WindowHeight { get; set; } = 200;
    }
