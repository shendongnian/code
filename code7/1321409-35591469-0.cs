    void dataGridView_AddingNewItem(object sender, System.Windows.Controls.AddingNewItemEventArgs e)
    {
        var item = new Competence();
        // Change item's values here.
        e.NewItem = item;
    }
