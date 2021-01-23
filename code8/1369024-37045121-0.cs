    public class DataGridViewItemFoo
    {
        public string Value { get; set; }
        public DataGridViewItemFoo(string value)
        {
            this.Value = value;
        }
    
    }
    
    List<DataGridViewItemFoo> affectedDbFoo = affectedDb.Select(ii => new DataGridViewItemFoo(ii)).ToList();
    
    dataGridView1.DataSource = affectedDbFoo;
