    public void UpdateFoodDrinkTobacco(int id, string preservationTechniqueCodes, bool isHomogenised)
        {
            var item = _db.FoodDrinkTobaccos.Where(i => i.id == id).Select(i => i).Single();
            if (item == null) return;
            item.preservationTechniqueCodes = preservationTechniqueCodes;
            item.isHomogenised = isHomogenised;
            _db.SubmitChanges();
        }
