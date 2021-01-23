    var selectedServices = lstServices.CheckedItems.Cast<ListViewItem>().Select(cs => cs.Tag);
    
    var anySelected = groupSet.Where(fg => TotalServices.Any(
        ts => ts.IDpack == fg.IDPack && selectedServices.Contains(ts.IDserv)));
    
    var allSelected = groupSet.Where(fg => TotalServices.Where(
        ts => ts.IDpack == fg.IDPack).DefaultIfEmpty().All(
        ts => ts != null && selectedServices.Contains(ts.IDserv)));
