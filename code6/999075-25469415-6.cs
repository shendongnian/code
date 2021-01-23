    public Form1()
    {
        InitializeComponent();
        DataTable dt = DAL.GetMockData();
        this.dataGridView1.DataSource = dt;
    }
    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        Dictionary<string, int> categoryNumber = GetUniqueCategories(sender as DataGridView);
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells["ProductCategory"].Value != null)
                row.DefaultCellStyle.BackColor = GetRowColor(categoryNumber[row.Cells["ProductCategory"].Value.ToString()]);
        }
    }
    private Color GetRowColor(int categoryNumber)
    {
        if (categoryNumber % 2 == 0)
            return Color.White; //default row color
        else
            return Color.LightGray; //alternate row color
    }
    private Dictionary<string, int> GetUniqueCategories(DataGridView dt)
    {
        int i = 0;
        Dictionary<string, int> categoryNumber = new Dictionary<string, int>();
        foreach (DataGridViewRow row in dt.Rows)
        {
            if (row.Cells["ProductCategory"].Value != null)
            {
                if (!categoryNumber.ContainsKey(row.Cells["ProductCategory"].Value.ToString()))
                {
                    categoryNumber.Add(row.Cells["ProductCategory"].Value.ToString(), i);
                    i++;
                }
            }
        }
        return categoryNumber;
    }
