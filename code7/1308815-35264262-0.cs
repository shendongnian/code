    var providerName = String.Empty;
    var parentTitle = "Parent";
    var relatedTitle = "RelatedItem3";
    
    DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
    Type parentType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.ParentModules.ParentModule");
    Type relatedType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.RelatedModules.RelatedModule");
    
    ContentLinksManager contentLinksManager = ContentLinksManager.GetManager();
    
    // get the live version of all parent items
    var parentItems = dynamicModuleManager.GetDataItems(parentType).Where(i => i.GetValue<string>("Title").Contains(parentTitle) && i.Status == ContentLifecycleStatus.Live && i.Visible);
    
    // get the ids of the related items.
    // We use the OriginalContentId property since we work with the live vesrions of the dynamic modules
    var parentItemIds = parentItems.Select(i => i.OriginalContentId).ToList();
    
    // get the live versions of all the schedules items
    var relatedItems = dynamicModuleManager.GetDataItems(relatedType).Where(i => i.Status == ContentLifecycleStatus.Live && i.Visible && i.GetValue<string>("Title").Contains(relatedTitle));
    
    // get the content links
    var contentLinks = contentLinksManager.GetContentLinks().Where(cl => cl.ParentItemType == parentType.FullName && cl.ComponentPropertyName == "RelatedField" && parentItemIds.Contains(cl.ParentItemId) && cl.AvailableForLive);
    
    // get the IDs of the desired parent items
    var filteredParentItemIds = contentLinks.Join<ContentLink, DynamicContent, Guid, Guid>(relatedItems, (cl) => cl.ChildItemId, (i) => i.OriginalContentId, (cl, i) => cl.ParentItemId).Distinct();
    
    // get the desired parent items by the filtered IDs
    var filteredParentItems = parentItems.Where(i => filteredParentItemIds.Contains(i.OriginalContentId)).ToList();
