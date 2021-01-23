    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue(string.Empty)]
    public override string Text
    {
        get {
            return txtBox.Text;
        }
        set {
            txtBox.Text  = value;
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue("My Lable:")]    
    public string LabelText
    {
        get{
            return lblLabel.Text;
        }
        Set {
            lblLabel.Text = value;
        }
    }
