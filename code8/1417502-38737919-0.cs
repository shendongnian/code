    OLVColumn column = new OLVColumn("HiddenGroupColumn", "ModelProperty");
    column.IsVisible = false;
    column.GroupKeyGetter = delegate(object x)
    {
        return ((Model)x).ModelProperty;
    };
