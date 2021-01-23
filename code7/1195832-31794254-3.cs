    var dm = DependencyResolver.Instance.GetInstance<IDataManagement>();
    var workItems = new List<DataManagementWorkItem>();
    try
    {
        var obs = dm.GetWorkItemSource(10).Do(workItems.Add);
        await obs;
        Assert.Fail("An expected exception was not thrown");
    }
    catch (Exception exc)
    {
        AssertTheRightException(exc);
        // workItems should be populated.
    }
