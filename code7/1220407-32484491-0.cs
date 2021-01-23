    // Make the Text property browsable again, call Refresh when changed.
    [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text 
    { 
        get
        {
            return _Text;
        }
        set
        { 
            if(_Text != value)
            {
                this.Refresh();
                _Text = value;
            }
        }
    }
    // Override Refresh to invalidate the relevant part of the parent form 
    public override void Refresh()
    {
        Form form = this.FindForm();
        if (this.BackColor == Color.Transparent && !string.IsNullOrEmpty(this.Text) && (this.Gradient.BackColor2==Color.Transparent || !this.Gradient.IsGradient) && this.BackgroundImage == null && form != null)
        {
            Point locationOnForm = form.PointToClient(this.Parent.PointToScreen(this.Location));
            form.Invalidate(new Rectangle(locationOnForm, this.Size));
        }
        base.Invalidate();
    }
