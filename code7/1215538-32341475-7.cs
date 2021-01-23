    private void InitializeListView(ImageList imgList)
    {
        lvExplorer.DoubleClick += new System.EventHandler(this.lvExplorer_DoubleClick);
        lvExplorer.SmallImageList = imgList;
        lvExplorer.LargeImageList = imgList;
        CreateHeaders();
        lvExplorer.View = View.Details;
    }
    private void CreateHeaders()
    {
        ColumnHeader header;
        header = new ColumnHeader();
        header.Text = "DirectoryName";
        lvExplorer.Columns.Add(header);
        header = new ColumnHeader();
        header.Text = "LastWriteTime";
        lvExplorer.Columns.Add(header);
    }
