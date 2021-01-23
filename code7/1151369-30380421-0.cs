    public Form1()
    {
      InitializeComponent();
    
      List<List<string>> options = new List<List<string>>()
      {
        new List<string>() { "Foo 1", "Foo 2", "Foo 3" },
        new List<string>() { "Bar 1", "Bar 2", "Bar 3" },
        new List<string>() { "Baz 1", "Baz 2", "Baz 3" }
      };
    
      List<string> names = new List<string>() { "Foo", "Bar", "Baz" };
    
      for (int i = 0; i < names.Count; i++)
      {
        DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
        col.Name = names[i];
        col.DataSource = options[i];
        this.dataGridView1.Columns.Add(col);
      } 
    }
