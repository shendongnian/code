    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool Selected
    {
        get
        {
            return false;
        }
        set
        {
            throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", new object[] { "Selected" }));
        }
    }
 
 
