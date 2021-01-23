    void changeButton_Click(object sender, EventArgs e)
    {
        list[2].Name = "Changed";
        list.RemoveAt(1);
        list.Add(new Category() { Id = 4, Name = "C4" });
    }
