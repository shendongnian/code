    private void button1_Click(object sender, EventArgs e)
    {
        rep.persons.Add(new Person("Tom Jones"));
        rep.persons.Add(new Person("Tom Hanks"));
        BindingSource bs = new BindingSource(rep, "persons");
        listBox1.DataSource = bs;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        rep.persons.Add(new Person("Tom Riddle"));
        BindingSource bs = (BindingSource)listBox1.DataSource;
        bs.ResetBindings(false);
    }
