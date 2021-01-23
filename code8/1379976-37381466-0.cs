    private void Update()
    {
        lbAnimals.Items.Clear();
        lbAnimals.Items.Clear();
        foreach (Cat c in reservations.Cats)
        {
            lbAnimals.Items.Add(c);
        }
        foreach (Dog d in reservations.Dogs)
        {
            lbAnimals.Items.Add(d);
        }
    }
