    public ActionResult PurchaseHistory()
            {
                //Get White Label ID to filter results
                var whiteLabelId = new WhiteLabelHelper().GetWhiteLabelId();
        
                var model = new List<PurchaseHistoryModel>();
        
        
        
                model = (from pc in db.PurchasedCards
                                      join c in db.Cards on pc.CardId equals c.CardId
                                      join u in db.Users on pc.UserId equals u.UserId
                                      join g in db.FundraisingGroups on pc.GroupId equals g.GroupId
                                      where c.WhiteLabelId == whiteLabelId
                                      select new PurchaseHistoryModel { Card = c.Name, User = u.Name, Group = g.Name, Proceeds = pc.NPOProceeds }).ToList();
        
        
        
                return View(model);
            }
