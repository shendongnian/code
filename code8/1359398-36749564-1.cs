    public void TakeOutTrash()
        {
            foreach (ComponentNodeViewModel root in this.FilterTreeItems)
            {
                FilterHolder = (ComponentNodeViewModel)root.Clone(trimIDs.TrashCan);
            }
        }
