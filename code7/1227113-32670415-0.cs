    public override void ItemAdded(SPItemEventProperties properties)
    {
        base.ItemAdded(properties);
        new PostTravelWizardWebPartUserControl().GeneratePDF();
    }
