    public partial class MainWindow : Window
    {
        Image img = new Image { Source = new BitmapImage(new Uri("C:\\Users\\Public\\Pictures\\Koala.jpg")) };
        public MainWindow()
        {
            InitializeComponent();
            MainCanvas.Focus();
            //this.Content = img; 
            //Content = img; //same as the above. you don't need to write "this".
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {// will work even if canvas has no background
            MainCanvas.Children.Add(img);
        }
        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            //event will not fire. Canvas does not get the focus
            //if you must have KeyDown trigger the event, you need MainCanvas.Focus() in the constructor, and Focusable="True" in the XAML.
            MainCanvas.Children.Add(img);
        }
        private void MainCanvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //This event will only fire if the canvas can get the focus: e.g. if it has some background.
            MainCanvas.Children.Add(img); //canvas control has the name MainCanvas inside the xaml
            //the below will work, but place the image on the window, because "this" means the class instance, not the method or event you are in.
            //this.Content = img;
        }
    }
