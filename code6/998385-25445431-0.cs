    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Description("extra free-form attributes on this thing.")]
    [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof(System.Drawing.Design.UITypeEditor))]
    public System.Collections.Specialized.StringCollection Items
    {
       get
       {
          if (items == null)
             items = new System.Collections.Specialized.StringCollection();
    
          return  this.items;
       }
    }
