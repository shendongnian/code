    public string Watermark {
        get { return this._watermark; }
        set {
            this._watermark = value;
            CueBannerHelper.SetCueBanner(this, value);
        }
    }
