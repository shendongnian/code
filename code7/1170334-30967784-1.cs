    public IList<Promotion> GetRewardsForUser(string userId)
    {
        //contains a list of Promotion.objectIds for that user
        IList<PromotionsClaimed> promosClaimed = _promotionsClaimedLogic
            .RetrieveByCriteria(t => t.userId == userId);
    
        var promotionIds = promosClaimed.Select(p => p.PromotionId).ToList();
    
        IList<Promotion> promos = _promotionLogic.Retrieve()
            .Where(p => promotionIds.Contains(p.objectId))
            .Select(p => new { PromoName = p.Name, PromoCode = p.Code });
    
        return selectedPromos;
    }
