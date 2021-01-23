      public ActionResult UpdateWishlist(FormCollection form)
        {
                       
            var allIdsToRemove = form["removefromcart"] != null 
                ? form["removefromcart"].Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList() 
                : new List<int>();
