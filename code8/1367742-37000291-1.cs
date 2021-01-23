    public bool AllSelected
    {
        get { return !this.MyCollection.Any(item => !item.IsSelected); }
        set
        {
            var toggle = this.MyCollection.Any(item => !item.IsSelected);
            foreach (var itm in this.MyCollection.Where(item => item.IsSelected != toggle))
                itm.IsSelected = toggle;
        }
    }
