    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
            // just set some properties of ink canvas, not directly relevant to your question
            ink.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;
            var attr = new InkDrawingAttributes();
            attr.Color = Colors.Red;
            attr.IgnorePressure = true;
            attr.PenTip = PenTipShape.Circle;
            attr.Size = new Size(4, 10);
            ink.InkPresenter.UpdateDefaultDrawingAttributes(attr);
        }
        private async void BtnSave_Click(object sender, RoutedEventArgs e) {
            // grab output file
            StorageFolder storageFolder = KnownFolders.SavedPictures;
            var file = await storageFolder.CreateFileAsync("output.jpg", CreationCollisionOption.ReplaceExisting);
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int) ink.ActualWidth, (int) ink.ActualHeight, 96);
            // grab your input file from Assets folder
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets");
            var inputFile = await assets.GetFileAsync("sample.jpg");            
            using (var ds = renderTarget.CreateDrawingSession()) {
                ds.Clear(Colors.White);                
                var image = await CanvasBitmap.LoadAsync(device, inputFile.Path);
                // draw your image first
                ds.DrawImage(image);
                // then draw contents of your ink canvas over it
                ds.DrawInk(ink.InkPresenter.StrokeContainer.GetStrokes());
            }
            // save results
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite)) {
                await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Jpeg, 1f);
            }
        }
    }
