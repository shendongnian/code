    protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
    {
        base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        ViewTreeObserver vto = this.ViewTreeObserver;
        vto.AddOnGlobalLayoutListener(this);
        vto.GlobalLayout += (sender, args) =>
        {
            if (!_hasLoaded)
            {
                Init();
                _hasLoaded =true;
            }
        };
    }
