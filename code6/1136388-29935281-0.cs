    //store checked Items
    public IEnumerable<string> SelectedSoftware { get; set; }
    //check box list items
    public List<string> SoftwareList = new List<string>();
     foreach (var item in Model.SoftwareList )
        {
            <input type="checkbox" name="SelectedSoftware" value="@item">@item
        }
