    List<PersonEntry> nameList = new List<PersonEntry>();
    ListBox listBox1 = new ListBox();
    foreach (string line in File.ReadAllLines("Personlist.txt"))
    {
        string[] tokens = line.Split(',');
        nameList.Add(new PersonEntry(tokens[0], tokens[1], tokens[2]));
    }
    listBox1.DataSource = nameList;
    listBox1.DataTextField = "name";
    listBox1.DataValueField = "name";
