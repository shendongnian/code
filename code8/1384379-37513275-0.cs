    private bool _updating;
    
    void CheckedBoxList_ItemCheck(sender object, EventArgs e)
    {
        if (_updating)  return;
        // Execute item check code
    }
    void SomewhereElse()
    {
        _updating = true;
        try {
            // programmatically check/uncheck items
        } finally {
            _updating = false;
        }
    }
