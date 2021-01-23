        public ActionResult UpdateAd(Ad ad)
        {
            ModelState.Remove("Title");
            ModelState.Remove("Text");
            ModelState.Remove("Price");
            var p = GetAd();   
            if (TryUpdateModel(p))
            {
                 //Save Changes;
            }
         }
