    private delegate void AddItem(string item);
    private AddItem addListItem;
    private void form_load()
    {
        new System.Threading.Thread(new ThreadStart(this.FillItems)).Start();
    }
    
    private void FillItems()
    {
        addListItem = new AddItem(this.addItem);
        ///Fill your list here
        this.Invoke(addListItem, "ABC");
        this.Invoke(addListItem, "XYZ");
        this.Invoke(addListItem, "PQR");
    }
     
    private void addItem(string item)
    {
       listView1.Items.Add(item);
    }
