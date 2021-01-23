    private ObservableCollection<article> _article
    public ObservableCollection<article> Article
    {
        get
        {
            if (_article == null)
                _article = this.GetAllArticle();
            return _article;
        }
    }
