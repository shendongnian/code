    List<ListItem> items = ListValueString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(lstItem => new { lstItem, listTexts = lstItem.Split(':') })
        .Select(x => new ListItem()
        {
            ListText = x.listTexts[0],
            ListId = Int32.Parse(x.listTexts[1]),
            IsActive = true,
            IsInUse = Int32.Parse(x.listTexts[1]) == _defaultString
        })
        .ToList();
    var _ListItems = new ObservableCollection<ListItem>(items);
