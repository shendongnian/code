    var contentManager = new Ektron.Cms.Framework.Content.ContentManager();
    var criteria = new Ektron.Cms.Content.ContentCriteria(ContentProperty.Id, EkEnumeration.OrderByDirection.Ascending);
    criteria.AddFilter(ContentProperty.FolderId, CriteriaFilterOperator.EqualTo, toUpdate.folder_id);
    criteria.OrderByDirection = Ektron.Cms.Common.EkEnumeration.OrderByDirection.Descending;
    criteria.OrderByField = Ektron.Cms.Common.ContentProperty.GoLiveDate;
    criteria.FolderRecursive = true;
    criteria.PagingInfo = new Ektron.Cms.PagingInfo(50, 1);
    var ektronItem = contentManager.GetItem((long) item.tctmd_id);
    if (ektronItem != null) // item exists in Ektron
    {
        // update taxonomy in Ektron
        var taxIds = item.taxonomy_ids;
        var taxonomyAPI = new Taxonomy();
        var taxData = taxonomyAPI.ReadAllAssignedCategory(ektronItem.Id);
        var taxManager = new Ektron.Cms.Framework.Organization.TaxonomyItemManager();
        var taxCriteria = new TaxonomyItemCriteria();
        // create a taxonomy criteria of the item ID
        taxCriteria.AddFilter(TaxonomyItemProperty.ItemId, CriteriaFilterOperator.EqualTo, item.tctmd_id);
        // get all taxonomy items with item ID 
        var taxItems = taxManager.GetList(taxCriteria);
        // determine taxonomyItemType
        var type = taxItems.FirstOrDefault().ItemType;
        foreach (var tax in taxData)
        {                      
            // delete from old taxonomies
            taxManager.Delete(tax.Id, (long)item.tctmd_id, type);
        }
        foreach (var tax in taxIds)
        {
            // add to new taxonomies
            var taxonomyItemData = new TaxonomyItemData()
            {
                TaxonomyId = tax,
                ItemType = type,
                ItemId = (long)item.tctmd_id
            };
            try
            {
                taxManager.Add(taxonomyItemData);
            }
            catch (Exception ex)
            {
                            
            }
        }
    }
