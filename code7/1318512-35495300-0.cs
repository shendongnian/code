    private BindingList<string> items = new BindingList<string>();
    public UserControl1() {
      InitializeComponent();
      comboBox1.DataSource = new BindingSource(items, string.Empty);
      comboBox2.DataSource = new BindingSource(items, string.Empty);
    }
    [MergableProperty(false)]
    [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(true)]
    public BindingList<string> Items {
      get { return items; }
    }
