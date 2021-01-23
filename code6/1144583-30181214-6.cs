    public ListItem GetListItem(CameraTable item)
    {
        var listItem = new ListItem(item.CameraName, item.IPAddress);
        if (string.IsNullOrEmpty(item.GroupName) == false)
            listItem.Attributes.Add("data-category", item.GroupName);
        return listItem;
    }
