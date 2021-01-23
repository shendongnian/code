    private Font m_Font = DefaultFont;
    
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [Description("The font of the text in the control")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Font Font
    {
        get { return m_Font; }
        set
        {
            m_Font = value;
            lb_Solution.Font = m_Font;
        }
    }
