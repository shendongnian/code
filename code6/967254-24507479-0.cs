    private void SynchronizeList()
    {
        // Set properties in each item
        foreach (var item in children)
        {
            //ListViewItem casted as ValueBoxControl
            ValueBoxControl control = (ValueBoxControl)item;
            //Standards & Limitations
            control.ValueTextBox.IsHitTestVisible = false;
            control.ClipColor = ClipColor;
            control.Foreground = this.Foreground;
        }
        List.Items.ReplaceAll(children.ToArray());
    }
