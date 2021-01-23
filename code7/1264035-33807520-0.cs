    string t = cmbRefrest.SelectedItem.ToString();
    if ("OFF" == t) timer.Enabled = false;
    else {
        int timeout = Int32.Parse(t) * 1000;
        timer.Interval = timeout;
        timer.Enabled = true;
    }
