    var selectedServiceIds = lstServices.CheckedItems.Cast<ListViewItem>().Select(cs => cs.Tag);
    
    var anySelected = groupSet.Where(fg => TotalServices.Any(
        ts => ts.IDpack == fg.IDPack && selectedServiceIds.Contains(ts.IDserv)));
    
    var allSelected = groupSet.Where(fg => selectedServiceIds.All(
        id => TotalServices.Any(ts => ts.IDpack == fg.IDPack && ts.IDserv == id)));
