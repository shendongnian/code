     public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    buffer = new ObservableCollection<Line>();
        
                    listBox.ItemsSource = buffer;
                    buffer.Add(new Line("Line1", new SolidColorBrush(Colors.Blue)));
                    buffer.Add(new Line("Line2", new SolidColorBrush(Colors.Green)));
                }
                private ObservableCollection<Line> buffer;   
        
                public class Line
                {
                    private string _message;
                    private Brush _background;
        
                    public Line(String message, Brush background)
                    {
                        this._message = message;
                        this._background = background;
                    }
        
                    public string Message
                    {
                        get { return _message; }
                        set { _message = value; }
                    }
        
                    public Brush Background
                    {
                        get { return _background; }
                        set { _background = value; }
                    }
                }
            }
         
