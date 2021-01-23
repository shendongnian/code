    var p = Process.GetProcessesByName("OtherApplication").FirstOrDefault();
    if (p != null)
    {
        if (p.Responding)
            MessageBox.Show("Responding");
        else
            MessageBox.Show("Not Responding");
    }
    else
    {
        MessageBox.Show("Not Running");
    }
