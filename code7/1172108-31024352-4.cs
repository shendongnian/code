        public IQueryable<ItemDTO> RepGetItems(string inOut, string planFact)
        {
            return GetItemsWithCategory().
                Where(i => i.InOut.Equals(inOut)).
                Where(i => i.PlanFact.Equals(planFact));
        }
