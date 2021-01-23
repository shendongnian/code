    Information info = new Information();
    info.Username = txtUsername.Text;
    info.Workstation = txtWorkstation.Text;
    // ...etc
    if (currentForm < info.Count)
    {
        info[currentForm] = info;
    }
    else
    {
        list.Add(info);
    }
    currentForm++;
