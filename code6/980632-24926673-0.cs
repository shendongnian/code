    Dictionary<Status, string> dict = new Dictionary<Status, string>();
    dct.Add(Status.Active, "Active");
    dct.Add(Status.Inactive, "Inactive");
    dct.Add(Status.Deleted, "Deleted");
    
    BindingSource src = new BindingSource();
    src.Datasource = dict;
    
    ((ListBox)YourCheckList).ValueMember = "key";
    ((ListBox)YourCheckList).DisplayMember = "value;
    ((ListBox)YourCheckList).Datasource = src;
    ((ListBox)YourCheckList).DataBind();
