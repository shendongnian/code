    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        var categories = new List<Category>()
        {
            new Category(){Id=1, Name= "One"},
            new Category(){Id=2, Name= "Two"},
            new Category(){Id=3, Name= "Three"},
        };
        this.comboBox1.DataSource = categories;
        this.comboBox1.DisplayMember = "Name";
        this.comboBox1.ValueMember = "Id";
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.comboBox1.SelectedValue = 2;
    }
