     public IList<Promotion> GetRewardsForUser(string userId)
    {
        //a list of all available promotions
        IList<Promotion> promos =  _promotionLogic.Retrieve();
        //contains a list of Promotion.objectIds for that user
        IList<PromotionsClaimed> promosClaimed = _promotionsClaimedLogic.RetrieveByCriteria(t => t.userId == userId);
        //should return a list of the Promotion name and code for the rewards claimed by user, but a complete list of Promotion entities would be fine
        var selectedPromos =
            (from promo in promos
            join promoClaimed in promosClaimed on promo.objectId equals promoClaimed.PromotionId
            select new { PromoName = promo.Name, PromoCode = promo.Code }).ToList();
        return selectedPromos;
    }
