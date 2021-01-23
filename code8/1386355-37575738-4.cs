    Information info = new Information();
    if (currentForm < info.Count)
    {
        info = list[currentForm];
    }
    info.Username = txtUsername.Text;
    info.Workstation = txtWorkstation.Text;
    // ...etc
    list.Add(info);
    currentForm++;
