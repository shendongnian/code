    private void Form_Load(object sender, EventArgs e)
    {
        var db = new TestDBEntities();
        
        //Select items that you need and shape it to ItemModel
        var list = db.Categories.Select(x => new ItemModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();
        //We cast the list to object[] because AddRange method accept object[]
        this.checkedListBox1.Items.AddRange(list.Cast<object>().ToArray());
    }
