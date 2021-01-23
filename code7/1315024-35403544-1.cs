    List<Foo> _lSource = new List<Foo>();
    
    private void radGridView1_UserAddedRow(object sender, GridViewRowEventArgs e)
    {
        Foo foo = new Foo();
        foo.Col1 = e.Row.Cells["col1"].Value.ToString();
        foo.Col2 = e.Row.Cells["col2"].Value.ToString();
    
        _lSource.Add(foo);
    }
