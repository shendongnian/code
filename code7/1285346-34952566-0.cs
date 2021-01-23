     public MainPage()
        {
            InitializeComponent();
            LayoutRoot.Drop += new DragEventHandler(drop);//important to add
        }
        private void drop(object sender, DragEventArgs e)
        {
            if (e.Data!=null)
            {
                FileInfo[] files = e.Data.GetData(DataFormats.FileDrop) as FileInfo[];
                foreach(var item in files)
                 {
                     //fullpath in: item.Fullname property
                  }
            }
        }
