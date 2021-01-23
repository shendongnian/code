        private void InitializeListView(ImageList imgList)
        {
            lvExplorer.DoubleClick += new System.EventHandler(this.lvExplorer_DoubleClick);
            lvExplorer.SmallImageList = imgList;
            lvExplorer.LargeImageList = imgList;
        }
