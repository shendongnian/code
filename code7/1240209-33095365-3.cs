    [HttpGet]
    public ActionResult GetLearnerTreasureItem(int Id)
    {
        using (The_Factory_Chante.Models.The_FactoryDBContext db2 = new The_Factory_Chante.Models.The_FactoryDBContext()) {
            learnerTreasureItem = db2.Learner_Treasure.Where(x => x.Id == Id);
            return Json(new { base64image = Convert.ToBase64String(learnerTreasureItem.itemImage) }, JsonRequestBehavior.AllowGet);
        }
    }
