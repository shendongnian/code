    public ActionResult COED()
        {
         var model = new SO_80.Models.Tables();
         string COED = "COED";
         Issue result = null;
         using (Entities db = new Entities())
                {
                  result = (from d in db.Issues
    			            join j in db.JiraAssignees on db.Issues equals j.ID 
                            where j.JiraIssueKey.ToLower().Trim().Contains(COED)
                            select d).FirstOrDefault();
                }
         return View(result);
        }
