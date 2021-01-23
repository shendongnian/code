    InvestigatorGroupModel groupModel = new InvestigatorGroupModel();
    
    GameClient proxy = new GameClient();
    groupModel.groupList = proxy.GetInvestigatorGroups(User.Identity.GetUserId());
    proxy.Close();
    //Save the list of InvestigatorGroupData objects to be retrieved later:
    HttpContext.Current.Session["GroupList"] = groupModel.groupList;
    
    return View("SelectGroup", groupModel);
