    public partial class PostBox : UserControl
    {
        public ObservableCollection<PostBoxPost> Posts = new ObservableCollection<PostBoxPost>();
        
        public PostBox()
        {
            InitializeComponent();
            Posts.CollectionChanged += OnPostsCollectionChanged;
        }
        private void OnPostsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Do your work here?
        }
    }
