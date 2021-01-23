    public string Content
    { 
        [UIHint("MyEditor"), AllowHtml]
        get { return _baseModel.Content; }
        set { _baseModel.Content = value; }
    }
