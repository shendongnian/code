    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    namespace VirtualizedListView
    {
        public partial class MainWindow : Window
        {
            private const string ThumbnailDirectory = @"D:\temp\thumbnails";
            private ConcurrentQueue<WriteableBitmap> _writeableBitmapCache = new ConcurrentQueue<WriteableBitmap>();
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                // Load thumbnail file names
                List<string> fileList = new List<string>(System.IO.Directory.GetFiles(ThumbnailDirectory));
                // Load view-model
                Thumbnails = new ObservableCollection<Thumbnail>();
                foreach (string file in fileList)
                    Thumbnails.Add(new Thumbnail(GetImageForThumbnail) { FilePath = file });
                // Create cache of pre-built WriteableBitmap objects; note that this assumes that all thumbnails
                // will be the exact same size.  This will need to be tuned for your needs
                for (int i = 0; i <= 99; ++i)
                    _writeableBitmapCache.Enqueue(new WriteableBitmap(256, 256, 96d, 96d, PixelFormats.Bgr32, null));
            }
            public ObservableCollection<Thumbnail> Thumbnails
            {
                get { return (ObservableCollection<Thumbnail>)GetValue(ThumbnailsProperty); }
                set { SetValue(ThumbnailsProperty, value); }
            }
            public static readonly DependencyProperty ThumbnailsProperty =
                DependencyProperty.Register("Thumbnails", typeof(ObservableCollection<Thumbnail>), typeof(MainWindow));
            private BitmapSource GetImageForThumbnail(Thumbnail thumbnail)
            {
                // Get the thumbnail data via the proxy in the other app domain
                ImageLoaderProxyPixelData pixelData = GetBitmapImageBytes(thumbnail.FilePath);
                WriteableBitmap writeableBitmap;
                // Get a pre-built WriteableBitmap out of the cache then overwrite its pixels with the current thumbnail information.
                // This avoids the memory pressure being set in this app domain, keeping that in the app domain of the proxy.
                while (!_writeableBitmapCache.TryDequeue(out writeableBitmap)) { Thread.Sleep(1); }
                writeableBitmap.WritePixels(pixelData.Rect, pixelData.Pixels, pixelData.Stride, 0);
                return writeableBitmap;
            }
            private ImageLoaderProxyPixelData GetBitmapImageBytes(string fileName)
            {
                // All of the BitmapSource creation occurs in this method, keeping the calls to 
                // MemoryPressure.ProcessAdd() localized to this app domain
                // Load the image from file
                BitmapFrame bmpFrame = BitmapFrame.Create(new Uri(fileName));
                int stride = bmpFrame.PixelWidth * bmpFrame.Format.BitsPerPixel;
                byte[] pixels = new byte[bmpFrame.PixelHeight * stride];
                // Construct and return the image information
                bmpFrame.CopyPixels(pixels, stride, 0);
                return new ImageLoaderProxyPixelData()
                {
                    Pixels = pixels,
                    Stride = stride,
                    Rect = new Int32Rect(0, 0, bmpFrame.PixelWidth, bmpFrame.PixelHeight)
                };
            }
            public void VirtualizingStackPanel_CleanUpVirtualizedItem(object sender, CleanUpVirtualizedItemEventArgs e)
            {
                // Get a reference to the WriteableBitmap before nullifying the property to release the reference
                Thumbnail thumbnail = (Thumbnail)e.Value;
                WriteableBitmap thumbnailImage = (WriteableBitmap)thumbnail.Image;
                thumbnail.Image = null;
                // Asynchronously add the WriteableBitmap back to the cache
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    _writeableBitmapCache.Enqueue(thumbnailImage);
                }), System.Windows.Threading.DispatcherPriority.Loaded);
            }
        }
        // View-Model
        public class Thumbnail : DependencyObject
        {
            private Func<Thumbnail, BitmapSource> _imageGetter;
            private BitmapSource _image;
            public Thumbnail(Func<Thumbnail, BitmapSource> imageGetter)
            {
                _imageGetter = imageGetter;
            }
            public string FilePath
            {
                get { return (string)GetValue(FilePathProperty); }
                set { SetValue(FilePathProperty, value); }
            }
            public static readonly DependencyProperty FilePathProperty =
                DependencyProperty.Register("FilePath", typeof(string), typeof(Thumbnail));
            public BitmapSource Image
            {
                get
                {
                    if (_image== null)
                        _image = _imageGetter(this);
                    return _image;
                }
                set { _image = value; }
            }
        }
        public class ImageLoaderProxyPixelData
        {
            public byte[] Pixels { get; set; }
            public Int32Rect Rect { get; set; }
            public int Stride { get; set; }
        }
    }
