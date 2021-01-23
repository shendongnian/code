    foreach (Control c in flowTrucks.Controls)
    {
        c.Width = 103;
        c.Height = 528;
    
        var x = c as UserControl1;
        if (x == null) continue; // not a UserControl1
        x.ResizeTrucks();
    }
