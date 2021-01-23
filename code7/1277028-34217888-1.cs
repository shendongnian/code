    private void Form1_Load(object sender, EventArgs e)
    {
        List<string> list1 = new List<string>();
        list1.Add("THE BOOK OF BURGER");
        list1.Add("The Hogwarts Library");
        list1.Add("NEW Day in the Life of a Farmer");
    
        List<string> list2 = new List<string>();
        list2.Add("$200");
        list2.Add("$150");
        list2.Add("$170");
    
    
        var list = new List<Book>();
        for (int i = 0; i < list1.Count; i++)
        {
            list.Add(new Book()
            {
                Title = list1[1],
                Price = list2[i]
            });
        }
    
        this.dataGridView1.DataSource = list;
    }
