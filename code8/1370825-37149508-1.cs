    public UCBind(DataRow row, ImageList imglist)
    {
        InitializeComponent();
        this.Doublebuffered = true;
        if (row != null)
        {
            imgList = imglist;
            DisplayData(row);
        }
    }
