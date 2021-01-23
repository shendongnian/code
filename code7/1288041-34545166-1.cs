    public virtual IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        var selections = new List<SelectItem>();
        var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
    
        var ownerContent = metadata.FindOwnerContent();
    
        if (ownerContent is Foo)
        {
            var containerRoot = contentRepository.GetChildren<ContainerOfSubFoo>(ownerContent.ParentLink).FirstOrDefault();
            var pageOptions = contentRepository.GetChildren<SubFoo>(containerRoot.ContentLink);
            foreach (var target in pageOptions)
            {
                selections.Add(new SelectItem() { Value = target.ContentLink.ID.ToString(), Text = target.SubFooProperty });
            }
        }
    
        return selections;
    }
