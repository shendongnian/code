    ListCollection = new ListCollectionView(RecordVms);
    ListCollection.GroupDescriptions?.Add(new PropertyGroupDescription("State"));
    ListCollection.Refresh();
    
    CollectionViewGroup group = (CollectionViewGroup) ListCollection.Groups[0];
    
    ListCollectionView viewOfGroup1 = new ListCollectionView(group.Items);            
    viewOfGroup1.Filter = ((i) => { return ((RecordVm)i).State == State.InProgress; });
    viewOfGroup1.Refresh();
