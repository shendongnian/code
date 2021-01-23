    private Constructor()
    {
        foreach (Control Item in this.Controls)
            Item.Leave += Item_Leave;
    }
    private void Item_Leave(object sender, EventArgs e)
    {
        Console.WriteLine("do something");
    }
