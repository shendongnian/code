    public void Remove()
    {
        if (Items.Count > 0)
        {
            DeactivateItem(Items[0], true);
        }
    }
