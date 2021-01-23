    var name = from a in ca.Clients select a.Name;
    AutoCompleteStringCollection sourcename = new AutoCompleteStringCollection();
    sourcename.AddRange(name.ToArray());
    this.tbName.AutoCompleteMode = AutoCompleteMode.Suggest;
    this.tbName.AutoCompleteSource = AutoCompleteSource.CustomSource;
    this.tbName.AutoCompleteCustomSource = sourcename;
