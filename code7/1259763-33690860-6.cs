    public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
    {
         global::xBindWithConverter.Item data = args.NewValue as global::xBindWithConverter.Item;
         if (args.NewValue != null && data == null)
         {
            throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::xBindWithConverter.Item was expected.");
         }
         this.SetDataRoot(data);
         this.Update();
    }
    // IDataTemplateExtension
    public bool ProcessBinding(uint phase)
    {
        throw new global::System.NotImplementedException();
    }
    public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
    {
        int nextPhase = -1;
        switch(args.Phase)
        {
            case 0:
                nextPhase = -1;
                this.SetDataRoot(args.Item as global::xBindWithConverter.Item);
                if (!removedDataContextHandler)
                {
                    removedDataContextHandler = true;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                }
                this.initialized = true;
                break;
        }
        this.Update_((global::xBindWithConverter.Item) args.Item, 1 << (int)args.Phase);
        return nextPhase;
    }
    ...
    public void Update()
    {
        this.Update_(this.dataRoot, NOT_PHASED);
        this.initialized = true;
    }
