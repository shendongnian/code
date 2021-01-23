    public MainPage() {
        InitializeComponent();
    
        this.Loaded += MainPage_Loaded;
      }
    
      private void MainPage_Loaded(object sender, RoutedEventArgs e) {
        photoChooserTask = new PhotoChooserTask();
        photoChooserTask.Completed += 
          new EventHandler<PhotoResult>(photoChooserTask_Completed);
      }
    
      private PhotoChooserTask photoChooserTask;
      private WriteableBitmap SelectedBitmap;
      private int i;
    
      public void photoChooserTask_Completed(object sender, PhotoResult e) {
        if (e.TaskResult != TaskResult.OK || e.ChosenPhoto == null)
        {
          return;
        }
        // create the image control
        Image img = new Image() { Width = 160, Height = 160 };
        SelectedBitmap = new WriteableBitmap(160, 160);
        SelectedBitmap.SetSource(e.ChosenPhoto);
        img.Source = SelectedBitmap;
        img.Name = "photo" + i++;
    
        // add new image control to canvas
        CollageCanvas.Children.Add(img);
    
        // add the ManipulationDelta event to the new image
        img.ManipulationDelta += img_ManipulationDelta;
    
        // Add a transform to the image
        // Eventually this transform is used to move the image to a new position
        // See  the ManipulationDelta event handler
        img.RenderTransform = new TranslateTransform();
      }
    
      private void img_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e) {
        // The ManipulationDelta occurs when the image is dragged to a new position
        var currentImage = sender as Image; // get the image
        var currentTransform = currentImage.RenderTransform as TranslateTransform;  // get the transform
    
        currentTransform.X += e.DeltaManipulation.Translation.X;
        currentTransform.Y += e.DeltaManipulation.Translation.Y;
      }
    
      private void Button_Click(object sender, RoutedEventArgs e) {
        photoChooserTask.Show();
      }
