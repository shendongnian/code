    [HttpGet]
    public ActionResult GetLearnerTreasureItem(int Id)
    {
        using (The_Factory_Chante.Models.The_FactoryDBContext db2 = new The_Factory_Chante.Models.The_FactoryDBContext()) {
            learnerTreasureItem = db2.Learner_Treasure.FirstOrDefault(x => x.Id == Id);
            return Json(new { image = Convert.ToBase64String(learnerTreasureItem.itemImage), treasureId = learnerTreasureItem.TreasureID }, JsonRequestBehavior.AllowGet);
        }
    }
