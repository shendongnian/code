    private void Form1_Load(object sender, EventArgs e)
    {
        var list = new List<LibraryItem>();
        list.Add(new Journal() { Title = "X", NumCopies = 100, Vol = 1 });
        list.Add(new Journal() { Title = "Y", NumCopies = 200, Vol = 2 });
        list.Add(new Book() { Title = "z", NumCopies = 300, Author= "A" });
        var bs = new BindingSource();
        bs.DataSource = list;
        this.dataGridView1.DataSource = bs;
    }
