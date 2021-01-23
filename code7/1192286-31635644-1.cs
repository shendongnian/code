    public ActionResult Bar()
    {
        List<MyModel> _model = new List<MyModel>();
        using (XmlReader reader = XmlReader.Create(url))
        {
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        foreach (SyndicationItem item in feed.Items)
        {
            var newItem = new MyModel();
            newItem.Topic = item.Title.Text;
            newItem.Signature = item.Summary.Text;
            newItem.Time = item.PublishDate.DateTime;
            _model.Add(newItem);
        }
      return PartialView("_Bar", _model); 
    }
