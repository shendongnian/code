    public JsonResult GetResponibleParty()
    {
        List<CI_ResponsibleParty> resParty;
        using (MetabaseDbContext context = new MetabaseDbContext())
        {
            resParty = context.SetOfResponsibleParty.ToList();
        }       
        return Json(resParty, JsonRequestBehavior.AllowGet);
    }
