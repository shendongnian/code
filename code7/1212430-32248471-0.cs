    /// <summary>
    /// The Lower Method CreateParams is being used to reduce flicker
    /// </summary>
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;
            return cp;
        }
    }
