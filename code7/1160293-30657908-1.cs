    List<CgValDetail> cgValDetail = new List<CgValDetail>();
    //Get cgValDetails for each control
    foreach (UiControlScreenMetaData tempUiControls in uiControls)
    {
        if (tempUiControls.CgValId == null)
        {
            continue;
        }
        List<CgValDetail> tempCgValDetail = Retrieval<CgValDetail>.Search(new { CgValId = tempUiControls.CgValId }).ToList();
        if (!tempCgValDetail.Any())
        {
            _foundationService.LogBusinessError(null, new ParameterBuilder("CgValId", tempUiControls.CgValId), "Invalid_CgValId_found");
            return false;
        }
        //Add tempCgValDetail List to main list which is cgValDetail
        cgValDetail.AddRange(tempCgValDetail);
    }
