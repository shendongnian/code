    public int IndexFromPoint(Point p)
    {
        return this.IndexFromPoint(p.X, p.Y);
    }
    public int IndexFromPoint(int x, int y)
    {
        var item = this.HitTest(x, y).Item;
        if (item != null)
            return item.Index;
        return -1;
    }
   
    private string displayMember;
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public string DisplayMember
    {
        get
        {
            return displayMember;
        }
        set
        {
            displayMember = value;
        }
    }
    private string valueMember;
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public string ValueMember
    {
        get
        {
            return valueMember;
        }
        set
        {
            valueMember = value;
        }
    }
