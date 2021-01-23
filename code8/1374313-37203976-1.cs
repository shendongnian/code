    public void CreateAndUse()
    {
        List<Item> instances;
        using (var p = new Project())
            instances = p.LoadItems();
    }
