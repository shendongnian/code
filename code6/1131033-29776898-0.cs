    [HttpPost]
        public ActionResult ProcessTypeStep()
        {
           var result = from a in db.ProcessTypeStep
           join b in db.ProcessStep on a.ProcessTypeStepId equals         b.ProcessTypeStepId
           join c in db.ProcessStepOwner on b.ProcessStepId equals     c.ProcessStepId
           join e in db.ProcessTypeStepDesc on a.ProcessTypeStepId equals     e.ProcessTypeStepId
    group by new
        {
            a.ProcessTypeStepId,
            e.ShortDescription
        } into GBC
    select new { GBC.ProcessTypeStepId, GBC.ShortDescription };
    result.Distinct();
    return Json(result, JsonRequestBehavior.AllowGet);
