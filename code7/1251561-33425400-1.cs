    protected PictureBox CloseButtonOfTabPage(TabPage tp)
    {
       return CloseButtonCollection
              .Where(item => item.Value == tp)
              .Select(item => item.Key).FirstOrDefault();
    }
