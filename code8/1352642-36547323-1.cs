    List<overviewModel> sortedOverviewModelList = overviewModelList.OrderBy(item => item.Position).ToList();
    overviewModel selectedItem = sortedOverviewModelList.Select(x => x.Id == PageId);
    int index = sortedOverviewModelList.IndexOf(selectedItem);
    int nextitem = index+1;
    int previtem = index-1;
