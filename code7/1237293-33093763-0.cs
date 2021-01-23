    IUIAutomationElement rootElement = uiAutomation.GetRootElement();
    // The first few steps below find a DataGridRowsPresenter for the 
    // DataGrid we're interested in.
    IUIAutomationElement dataGridRowsPresenter = null;
    // We'll be setting up various UIA conditions and cache requests below.
    int propertyIdControlType = 30003; // UIA_ControlTypePropertyId
    int propertyIdName = 30005; // UIA_NamePropertyId
    int propertyIdAutomationId = 30011; // UIA_AutomationIdPropertyId
    int propertyIdClassName = 30012; // UIA_ClassNamePropertyId
    int controlTypeIdDataItem = 50029; // UIA_DataItemControlTypeId
    // Look for the test app presenting the DataGrid. For this test, assume there's
    // only one such UIA element that'll be found, and the current language doesn't
    // effect any of the searches below.
    string testAppName = "Window1";
    IUIAutomationCondition conditionTestAppName =
        uiAutomation.CreatePropertyCondition(
            propertyIdName, testAppName);
    IUIAutomationElement testAppElement =
        rootElement.FindFirst(
            TreeScope.TreeScope_Children,
            conditionTestAppName);
    // Did we find the test app?
    if (testAppElement != null)
    {
        // Next find the DataGrid. By looking at the UI with the Inspect SDK tool first,
        // we can know exactly how the UIA hierarchy and properties are being exposed.
        string dataGridAutomationId = "DataGrid_Standard";
        IUIAutomationCondition conditionDataGridClassName =
            uiAutomation.CreatePropertyCondition(
                propertyIdAutomationId, dataGridAutomationId);
        IUIAutomationElement dataGridElement =
            testAppElement.FindFirst(
                TreeScope.TreeScope_Children,
                conditionDataGridClassName);
        // Did we find the DataGrid?
        if (dataGridElement != null)
        {
            // We could simply look for all DataItems that are descendents of the DataGrid.
            // But we know exactly where the DataItems are, so get the element that's the 
            // parent of the DataItems. This means we can then get that element's children,
            // and not ask UIA to search the whole descendent tree.
            string dataGridRowsPresenterAutomationId = "PART_RowsPresenter";
            IUIAutomationCondition conditionDataGridRowsPresenter =
                uiAutomation.CreatePropertyCondition(
                    propertyIdAutomationId, dataGridRowsPresenterAutomationId);
            dataGridRowsPresenter =
                dataGridElement.FindFirst(
                    TreeScope.TreeScope_Children,
                    conditionDataGridRowsPresenter);
        }
    }
    // Ok, did we find the element that's the parent of the DataItems?
    if (dataGridRowsPresenter != null)
    {
        // Making cross-proc calls is slow, so try to reduce the number of cross-proc calls we 
        // make. In this test, we can find all the data we need in a single cross-proc call below.
        // Create a condition to find elements whose control type is DataItem.
        IUIAutomationCondition conditionRowsControlType =
            uiAutomation.CreatePropertyCondition(
                propertyIdControlType, controlTypeIdDataItem);
        // Now say that all elements returned from the search should have their Names and
        // ClassNames cached with them. This means that when we access the Name and ClassName
        // properties later, we won't be making any cross-proc call at that time.
        IUIAutomationCacheRequest cacheRequestDataItemName = uiAutomation.CreateCacheRequest();
        cacheRequestDataItemName.AddProperty(propertyIdName);
        cacheRequestDataItemName.AddProperty(propertyIdClassName);
        // Say that we also want data from the children of the elements found to be cached 
        // beneath the call to find the DataItem elements. This means we can access the Names 
        // and ClassNames of all the DataItems' children, without making more cross-proc calls.
        cacheRequestDataItemName.TreeScope =
            TreeScope.TreeScope_Element | TreeScope.TreeScope_Children;
        // For this test, say that we don't need a live reference to the DataItems after we've 
        // done the search. This is ok here, because the cached data is all we need. It means
        // that we can't later get current data (ie not cached) from the DataItems returned.
        cacheRequestDataItemName.AutomationElementMode =
            AutomationElementMode.AutomationElementMode_None;
        // Now get all the data we need, in a single cross-proc call.
        IUIAutomationElementArray dataItems = dataGridRowsPresenter.FindAllBuildCache(
            TreeScope.TreeScope_Children,
            conditionRowsControlType,
            cacheRequestDataItemName);
        if (dataItems != null)
        {
            // For each DataItem found...
            for (int idxDataItem = 0; idxDataItem < dataItems.Length; idxDataItem++)
            {
                IUIAutomationElement dataItem = dataItems.GetElement(idxDataItem);
                // This test is only interested in DataItems with a Name.
                string dataItemName = dataItem.CachedName;
                if (!string.IsNullOrEmpty(dataItemName))
                {
                    // Get all the direct children of the DataItem, that were cached 
                    // during the search.
                    IUIAutomationElementArray elementArrayChildren = 
                        dataItem.GetCachedChildren();
                    if (elementArrayChildren != null)
                    {
                        int cChildren = elementArrayChildren.Length;
                        // For each child of the DataItem...
                        for (int idxChild = 0; idxChild < cChildren; ++idxChild)
                        {
                            IUIAutomationElement elementChild =
                                elementArrayChildren.GetElement(idxChild);
                            if (elementChild != null)
                            {
                                // This test is only interested in the cells.
                                if (elementChild.CachedClassName == "DataGridCell")
                                {
                                    string cellName = elementChild.CachedName;
                                    // Do something useful with the cell name now...
                                }
                            }
                        }
                    }
                }
            }
        }
    }
