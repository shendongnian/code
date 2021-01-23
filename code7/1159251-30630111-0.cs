    public class ViewModel : DependencyObject
    {
        public ICommand ChangeWidthCommand { get; set; }
        public int CanvasWidth
        {
            get { return (int)GetValue(CanvasWidthProperty); }
            set { SetValue(CanvasWidthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CanvasWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanvasWidthProperty =
            DependencyProperty.Register("CanvasWidth", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public ViewModel()
        {
            ChangeWidthCommand = new ChangeWidthCommand(this);
        }
    }
