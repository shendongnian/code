        protected override DriverResult Display(
        McrfProfilePart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
           ContentShape("Parts_McrfProfile",
                             () =>
                             {
                                 part.ProfileDetail = _profileService.GetProfileDetail(part.ProfileId);
                                 McrfProfileDetailViewModel profileDetailViewModel = new McrfProfileDetailViewModel();
                                 profileDetailViewModel.ProfileDetail = part.ProfileDetail;
                                 return shapeHelper.Parts_McrfProfile(ProfileDetail: profileDetailViewModel);
                              }),
            ContentShape("Parts_McrfProfile_List",
                             () =>
                             {
                                 return shapeHelper.Parts_McrfProfile_List(ProfileRecord: part);
                             }),
            ContentShape("Parts_McrfProfile_Summary",
                             () =>
                             {
                                 McrfProfileSummaryViewModel profileSummaryViewModel = new McrfProfileSummaryViewModel();
                                 List<int> profileID = new List<int>() { part.ProfileId };
                                 var summary = _profileService.GetProfileSummaryList(profileID).Where(e => e.ProfileID == part.ProfileId).First();
                                 profileSummaryViewModel.JobTitle = summary.JobTitle;
                                 profileSummaryViewModel.Name = summary.Name;
                                 profileSummaryViewModel.ProfileImage = summary.ProfileImage;
                                 profileSummaryViewModel.ProfileID = summary.ProfileID;
                                 return shapeHelper.Parts_McrfProfile_Summary(ProfileRecord: profileSummaryViewModel);
                             }));
        }
