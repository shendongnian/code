    public ActionResult getMailingLists(jQueryDataTableParamModel param)
    {
        svcMailListAdmin.PreInvoke();
        svcMailListAdmin.AddParameter("AuthUserName", SM_AuthUserName);
        svcMailListAdmin.AddParameter("AuthPassword", SM_AuthPassword);
        svcMailListAdmin.AddParameter("DomainName", SM_DomainName);
        svcMailListAdmin.Invoke("GetMailingListsByDomain");
        svcMailListAdmin.PostInvoke();
        var resultXML = svcMailListAdmin.ResultXML;
        var resultsList = resultXML.Root.Elements("listNames")
                        .Elements("string")
                        .Select(i => new List<string>()
                        {
                            (string)i
                        }).ToList();
        return Json(new
        {
            sEcho = param.sEcho,
            iTotalRecords = resultsList.Count,
            iTotalDisplayRecords = resultsList.Count,
            aaData = resultsList
        },
        JsonRequestBehavior.AllowGet);
    }
