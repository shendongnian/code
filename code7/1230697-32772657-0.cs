    public ActionResult Intermediate()
    {
         If(ViewBag.correct > Gameinfo.correct)
         {
               Gameinfo.correct++;
         }
    }
