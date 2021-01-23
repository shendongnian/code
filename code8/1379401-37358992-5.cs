    private class Row
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Row(string i, int q, double p)
        {
            this.ItemName = i;
            this.Quantity = q;
            this.Price = p;
        }
    }
    private List<Row> rows = new List<Row>();
    private void Form1_Load(object sender, EventArgs e)
    {
        // instead, here you will add your rows from SQL
        rows.AddRange(new Row[]
        {
            new Row("item1", 0, 500),
            new Row("item2", 0, 400),
            new Row("item3", 0, 850)
        });
        this.dataGridView1.DataSource = rows;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        Add.Click += quantityChangeClick;
        Minus.Click += quantityChangeClick;
    }
