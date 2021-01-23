    /// <summary>
    /// Gets or sets the watermark that the control contains.
    /// </summary>
    [Description("The watermark that the control contains."),
        Category("Appearance"),
        DefaultValue(null),
        Browsable(true)
    ]
    public string Watermark {
        get { return this._watermark; }
        set {
            this._watermark = value;
            CueBannerHelper.SetCueBanner(this, value);
        }
    }
