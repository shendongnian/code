    ObservableCollection<Post> _posts = new ObservableCollection<Post>();
    public ObservableCollection<Post> Posts { get { return _posts; } }
    public NewsPageViewModel()
    {
        GetPosts(_posts);
    }
    public static void GetPosts(ObservableCollection<Post> posts)
    {
        posts.Clear();
        //  ...get posts
    }
