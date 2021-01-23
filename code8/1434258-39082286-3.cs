    namespace Test
    {
    public class DrawingVisualObject : DrawingVisual
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrawingVisualObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DrawingVisualObject> DrawingVisualCollection
        {
            get { return (ObservableCollection<DrawingVisualObject>)GetValue(DrawingVisualCollectionProperty); }
            set { SetValue(DrawingVisualCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DrawingVisualCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawingVisualCollectionProperty =
            DependencyProperty.Register("DrawingVisualCollection", typeof(ObservableCollection<DrawingVisualObject>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<DrawingVisualObject>()));
        public MainWindow()
        {
            InitializeComponent();
            List<DrawingVisualObject> sample = new List<DrawingVisualObject>();
            sample.Add(new DrawingVisualObject(1, "Yolo"));
            sample.Add(new DrawingVisualObject(2, "Swag"));
            this.FillCollection(sample);
        }
        public void FillCollection(IEnumerable<DrawingVisualObject> objects2fill)
        {
            this.DrawingVisualCollection.Clear();
            foreach(DrawingVisualObject obj in objects2fill)
            {
                this.DrawingVisualCollection.Add(obj);
            }
        }
    }
