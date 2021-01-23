    var controlsToRemove = new List<Control>();
    foreach (Control c in this.Controls)
    {
        if (c is BnBCalculator.SmartTextBox) 
            controlsToRemove.Add(c);
    }
    
    foreach (Control c in controlsToRemove)
    {
        Controls.Remove(c);
    }
