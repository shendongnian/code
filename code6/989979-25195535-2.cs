    IEnumerable<string> personNames = PersonnelObject.Select(x => x.Name);
    PersonnelName = new ObservableCollection<string>();// optional if not initialized
    foreach(string pName in personNames )
    {
        PersonnelName.Add(pName);
    }
