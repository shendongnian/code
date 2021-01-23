        if (myItemsControlInstance.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            // You should be able to get the container using ContainerFromItem
        }
        else
        {
            // You will have to wait
            myItemsControlInstance.ItemContainerGenerator.StatusChanged += myItemsControlInstance_ContainersGenerated;
        }
    ...
    void myItemsControlInstance_ContainersGenerated(object sender, EventArgs e)
    {
        if (myItemsControlInstance.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            myItemsControlInstance.ItemContainerGenerator.StatusChanged -= myEventHandler;
            // You should be able to get the container now using ContainerFromItem.
            // However, layout hasn't been performed on it yet at this point, so there is no guarantee that the item
            // is in good condition to be messed with yet.
            LayoutUpdated += app_LayoutUpdated;
        }
    }
    void app_LayoutUpdated(object sender, EventArgs e)
    {
        LayoutUpdated -= app_LayoutUpdated;
        if (myItemsControlInstance.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            // Now, you can finally get the container using ContainerFromItem and do something with it.
        }
        else
        {
            // It looks like more items needed to be generated...
            myItemsControlInstance.ItemContainerGenerator.StatusChanged += myItemsControlInstance_ContainersGenerated;
        }
    }
