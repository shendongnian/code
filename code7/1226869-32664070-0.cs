    public class MainViewModel : ViewModelBase
    {
        private readonly string pathToWatch;
        private const string FileToWatch = "test.ini";
        private string fileText;
        public string FileText
        {
            get { return fileText; }
            set
            {
                if (fileText == value) return;
                fileText = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            pathToWatch = Environment.GetEnvironmentVariable("UserProfile") + @"\DeskTop\";
            RunWatch();
        }
        public void RunWatch()
        {
            var watcher = new FileSystemWatcher();
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // FILE TO WATCH PATH AND NAME. 
            watcher.Path = pathToWatch;
            watcher.Filter = FileToWatch;
            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
        // Define the event handlers. 
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //THE FILE CHANGED NOW LET'S UPDATE THE TEXT.
            try
            {
                //Read file update the Graphical User Interface 
                FileText = File.ReadAllText(pathToWatch + FileToWatch);
            }
            catch (FileNotFoundException)
            {
                FileText = "File not found.";
            }
            catch (FileLoadException)
            {
                FileText = "File Failed to load";
            }
            catch (IOException)
            {
                FileText = "File I/O Error";
            }
            catch (Exception err)
            {
                FileText = err.Message;
            }
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // There will be code here to re-create file if it is renamed
        }
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
