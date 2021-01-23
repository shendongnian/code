    public ViewModel()
            {
                Test = new Collection<SelectableItem>
                    {
                        new SelectableItem { ItemDescription = "Option 1"},
                        new SelectableItem { ItemDescription = "Option 2"},
                        new SelectableItem { ItemDescription = "Option 3", IsSelected = true},
                        new SelectableItem { ItemDescription = "Option 4"}
                    };
            }
