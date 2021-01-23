    string DSName = ddDataSourceSelect.SelectedValue.ToString();
    
    List<ReportService2010.ItemReference> itemRefs = new List<ReportService2010.ItemReference>();
    ReportService2010.DataSource[] itemDataSources = rs.GetItemDataSources("/" + location + "/" + filename);
    
    foreach (ReportService2010.DataSource itemDataSource in itemDataSources)
    {
        ReportService2010.ItemReference itemRef = new ReportService2010.ItemReference();
        itemRef.Name = itemDataSource.Name;
    
        itemRef.Reference = "/" + DSName;
    
        itemRefs.Add(itemRef);
    }
    
    rs.SetItemReferences("/" + location + "/" + filename, itemRefs.ToArray());
