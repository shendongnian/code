    Information info = new Information();
    info.Username = txtUsername.Text;
    info.Workstation = txtWorkstation.Text;
    // ...etc
    if (currentForm < list.Count)
    {
        list[currentForm] = info;
    }
    else
    {
        list.Add(info);
    }
    currentForm++;
