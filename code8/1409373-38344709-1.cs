    public bool FixedContent
    {
        get { return (bool)GetValue(FixedContentProperty); }
        set
        {
            SetValue(FixedContentProperty, value);
            if (value) // Is Fixed
            {
                ResizableContentPresenter.Content = null;
                FixedContentPresenter.Content = Content;
            }
            else
            {
                FixedContentPresenter.Content = null;
                ResizableContentPresenter.Content = Content;
            }
        }
    }
