    ToggleButton[] btnArray = new ToggleButton[] {b1, b2, b3};
    
    public SwitchButton(int index)
    {
        foreach(var btn in btnArray)
        {
            // Set all buttons deactive (no hover)
            btn.Color = deactiveColor; // Example
        }
        
        // Set specified (by index) btn active (hover)
        var btn = btnArray[index];
        btn.Color = activeColor; // Example
    }
