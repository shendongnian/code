    //In the CW class:
    public void OnSelectionChanged()
    {
        var handler = SelectionChanged;
        if (handler != null)
             handler(this, //[ some int value here ]);
    }
