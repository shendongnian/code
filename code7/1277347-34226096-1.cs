    private void GetMapRules(UndoRedoCollection undoRedoCollection)
    {
        foreach (var item in undoRedoCollection)
        {
            this.Add(new Map(item, this));
           }
        }
    }
