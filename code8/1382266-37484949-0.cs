    using Callisto.Controls;
    using System;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    
    namespace FlipViewTest
    {
        public sealed partial class MainPage : Page
        {
            public ObservableCollection<BitmapImage> FlipImages = new ObservableCollection<BitmapImage>();
    
            public MainPage()
            {
                this.InitializeComponent();
                this.addItemsToFlipView();
            }
    
            private void addItemsToFlipView()
            {
                for (int i = 0; i < 9; i++)
                {
                    string imageUri = String.Format(@"ms-appx:///Assets/Images/FlipImage-0{0}.jpg", i + 1);
                    Uri uri = new Uri(imageUri);
                    BitmapImage image = new BitmapImage(uri);
                    FlipImages.Add(image);
                }
                mainFlipView.ItemsSource = FlipImages;
            }
        }
    }
