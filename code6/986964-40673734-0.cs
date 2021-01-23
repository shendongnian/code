    foreach (YourCollectionType item in datagrid.Items)
    {
         var children = datagrid.ItemsSource.OfType<YourCollectionType>().Where(x => x.Item1 == item.Item1 && x.Item2 == item.Item2 && x.Item3 == item.Item3 && x.Item4 == item.Item4);
         item.Results = children.Count();
         Trace.TraceInformation(item.Results.ToString());
    }
