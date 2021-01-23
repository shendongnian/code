    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateBilboard();
        }
       
        private void CreateBilboard()
        {
            BitmapImage im = new BitmapImage(new System.Uri(@"C:\Users\Public\Pictures\Sample Pictures\Lighthouse.jpg"));
            var mat = MaterialHelper.CreateImageMaterial(im, 1);
            var bboard = new BillboardVisual3D();
            bboard.Material = mat;
            var position = new System.Windows.Media.Media3D.Point3D(0, 0, 0);
            var width = 100;
            var height = 100;
            //set coordinates 
            bboard.Position = position;
            bboard.Width = width;
            bboard.Height = height;
            //add the billboard 
            viewPort.Children.Add(bboard);
        }
    }
