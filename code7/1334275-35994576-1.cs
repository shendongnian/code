    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentBlockList pp = new ContentBlockList();
            pp.CollectionChanged += pp_CollectionChanged;
            pp.CollectionChanged += pp_CollectionChanged1; 
            pp.Add(11112);
    
            pp.SomeMethod();
        }
    
        void pp_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
    
        void pp_CollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
    
        }
       
       
    }
    
    public class ContentBlockList : ObservableCollection<int>
    {
        public void SomeMethod()
        {
            var handlers = CollectionChanged.GetInvocationList();
    
            foreach (NotifyCollectionChangedEventHandler handler in handlers)
            {
                CollectionChanged -= handler;
            }
    
            // do stuff here
    
            foreach (NotifyCollectionChangedEventHandler handler in handlers)
            {
                CollectionChanged += handler;
            }
        }
    
        public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
    }
       
 
