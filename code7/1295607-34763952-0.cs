    public List<Items> LoadLineItemByPkeys(IEnumerable<long> itemIds)
    {
        var lineItemList = CurrentSession.QueryOver<LineItem>()
          .WhereRestrictionOn(l =>l.id).IsIn(itemIds).List()
          .ToList();
        return lineItemList ;
    }
