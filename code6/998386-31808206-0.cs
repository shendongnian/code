    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<string> TestList { get; set; }
    
    public ListTest()
    {
        TestList = new List<string>();
    }
