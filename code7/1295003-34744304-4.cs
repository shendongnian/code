    private readonly Data _data;
    public Form1()
    {
         _data = new Data();
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var dataTable = _data.DataService()
        dataGridView1.DataSource = dataTable ;
        for (int i = 0; i < dataTable.Rows.Count; i++)//showing error for 'for'
        {
            comboBox1.Items.Add(dataTable.Rows[i]["City"]);
        }
     }
  }
  
