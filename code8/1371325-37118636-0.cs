    [Bindable(false), EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
        get
        {
            return _isWatermarked ? string.Empty : base.Text;
        }
        set
        {
            base.Text = value;
        }
    }
