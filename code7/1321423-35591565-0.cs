    [HttpGet]
    public ActionResult FillOut ( Guid pid, int? sid )
    {
     // pid: partner id
     // sid (optional): survey id
    // if survey id not supplied in query string, find which survey the user should be on
        if ( !sid.HasValue )
        {
            sid = this._Db.CheckIfFinished(pid, 1) ? 2 : 1;
        }
        ViewBag.pid = pid;
        ViewBag.sid = sid;
        ViewBag.finished = this._Db.CheckIfFinished(pid,sid);
        ViewBag.survtitle = this._Db.GetSurveyTitle(sid);
        var AllAnswers = this._Db.GetAnswersByPartner(pid,sid.Value);
