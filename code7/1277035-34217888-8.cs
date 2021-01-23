    var list = new List<Book>();
    for (int i = 0; i < list1.Count; i++)
    {
        list.Add(new Book()
        {
            Title = list1[i],
            Price = list2[i]
        });
    }
    this.dataGridView1.AutoGenerateColumns = true;
    this.dataGridView1.DataSource = list;
