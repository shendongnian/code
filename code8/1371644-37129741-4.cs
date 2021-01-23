    public class ImageConverter : IValueConverter
    {
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                string imageUrl = value.ToString();
                if (imageUrl.Contains("NoImageIcon"))
                    return value;
                if (imageUrl.Contains(Constants.IMAGES_FOLDER_PATH))
                {
                    var task = Task.Run(()=>( (GetImage((String)value))));
                     return new TaskCompletionNotifier<BitmapImage>(task);
                   
                }
                if (imageUrl.Contains("mp4"))
                {
                    return new TaskCompletionNotifier<BitmapImage>(Task.Run(() => ((GetImage("ms-appx:///Images/video.png")))));
                    
                    
                }
                if (MCSManager.Instance.isInternetConnectionAvailable)
                {
                    return new TaskCompletionNotifier<BitmapImage>(Task.Run(() => ((GetImage(value.ToString(),true)))));
                }
                else
                {
                    var task = Task.Run(() => ((GetImage("ms-appx:///Images/defaultImage.png"))));
                    return new TaskCompletionNotifier<BitmapImage>(task);
                }
            }
            return new Uri("ms-appx:///Images/defaultImage.png", UriKind.RelativeOrAbsolute);
        }
        private async Task<BitmapImage> GetImage(string path,bool link=false)
        {
            BitmapImage image=null;
            var dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
            try
            {
               
              await  dispatcher.RunAsync(CoreDispatcherPriority.Normal,async () =>
                {
                    if (link)
                    {
                        image = new BitmapImage();
                        image.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                        
                    }
                    else
                    {
                        image = new BitmapImage();
                        image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                        StorageFile imagefile = await localFolder.GetFileAsync(path);
                        using (IRandomAccessStream fileStream = await imagefile.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            image.SetSource(fileStream);
                            
                        }
                    }
                });
                return image;
            }
            catch(Exception e)
            {
                return null;
            }
          
           
        }
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return null;
        }
        private async Task<bool> FileExists(string fileName)
        {
            try
            {
                StorageFile file = await localFolder.GetFileAsync(fileName);
                return true;
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
        }
    }
    public sealed class TaskCompletionNotifier<TResult> : INotifyPropertyChanged
    {
        public TaskCompletionNotifier(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var scheduler = (SynchronizationContext.Current == null) ? TaskScheduler.Current : TaskScheduler.FromCurrentSynchronizationContext();
                task.ContinueWith(t =>
                {
                    var propertyChanged = PropertyChanged;
                    if (propertyChanged != null)
                    {
                        propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
                        if (t.IsCanceled)
                        {
                            propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
                        }
                        else if (t.IsFaulted)
                        {
                            propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                            propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                        }
                        else
                        {
                            propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                            propertyChanged(this, new PropertyChangedEventArgs("Result"));
                        }
                    }
                },
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                scheduler);
            }
        }
        // Gets the task being watched. This property never changes and is never <c>null</c>.
        public Task<TResult> Task { get; private set; }
       
        // Gets the result of the task. Returns the default value of TResult if the task has not completed successfully.
        public TResult Result { get { return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult); } }
        // Gets whether the task has completed.
        public bool IsCompleted { get { return Task.IsCompleted; } }
        // Gets whether the task has completed successfully.
        public bool IsSuccessfullyCompleted { get { return Task.Status == TaskStatus.RanToCompletion; } }
        // Gets whether the task has been canceled.
        public bool IsCanceled { get { return Task.IsCanceled; } }
        // Gets whether the task has faulted.
        public bool IsFaulted { get { return Task.IsFaulted; } }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
